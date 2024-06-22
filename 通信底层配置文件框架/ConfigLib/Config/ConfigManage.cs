using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Wen.BLL;
using Wen.Models;

namespace   ConfigLib
{
    public class ConfigManage
    {
        /// <summary>
        /// 导出配置
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public bool ExportProjects(string path,string projectName)
        {
            try
            {
                //从数据库查询，遍历得到所有的信息
                //就不需要在Main程序中，一次次添加或者修改数据
                List<ProjectsModel> projects = new ProjectBLL().SelectProject();

                foreach (var project in projects)
                {
                    Dictionary<int, List<EquipmentsModel>> dic = new EquipMentBLL().QueryEquipments(project.Projectid);

                    foreach (List<EquipmentsModel> item in dic.Values)
                    {
                        project.EquipmentMoedelList.AddRange(item);
                    }

                    foreach (var equip in project.EquipmentMoedelList)
                    {
                        equip.CGroupList = new CommunicationsGroupBLL().SelectCommunticationGroup(equip.Equipmentid);

                        foreach (var gp in equip.CGroupList)
                        {
                            gp.VarList = new VariableBLL().QueryVariable(gp.Cgid);
                        }
                    }
                }

                //转换
                List<Project> projectList = TransformProjects(projects,projectName);

                //序列化

                string json = JsonHelper.EntityToJson(projectList);

                File.WriteAllText(path, json);


                return true;
            }
            catch
            {
                return false;
            }


        }

        /// <summary>
        /// 导入配置信息
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>

        public List<Project> LoadProjects(string path)
        {
            string json = File.ReadAllText(path);

            List<Project> projects = JsonHelper.JsonToEntity<List<Project>>(json);

            return projects;
        }

        /// <summary>
        /// 将配置软件里的实例类集合（即数据库）转换成配置库里的实例类集合
        /// </summary>
        /// <param name="projects"></param>
        /// <returns></returns>
        public List<Project> TransformProjects(List<ProjectsModel> projects,string projectName)
        {
            List<Project> result = new List<Project>();

            foreach (ProjectsModel pro in projects)
            {
                Project project = null;
                if (pro.Projectname==projectName)
                {
                    project = new Project();
                    project.ProjectName = pro.Projectname;

                    foreach (var eq in pro.EquipmentMoedelList)
                    {
                        if (eq.Isenable != 1)
                        {
                            continue;
                        }

                        switch (eq.PtypeName)
                        {
                            case "西门子S7":
                                SiemensDevice siemensDevice = new SiemensDevice();
                                //得到西门子S7通信，所需的IP,设备名称,端口号，激活
                                siemensDevice.DeviceName = eq.EquipmentName;
                                siemensDevice.Ipaddress = eq.Ipaddress;
                                siemensDevice.Port = Convert.ToInt32(eq.Portno);
                                siemensDevice.IsActive = eq.Isenable == 1;

                                //用描述来表示CPUType
                                siemensDevice.CPUType = eq.Comments;

                                //遍历设备通信组，得到通信组的名字，需要起始地址，是否激活，以及长度
                                foreach (var gp in eq.CGroupList)
                                {

                                    SiemensGroup siemensGroup = new SiemensGroup();
                                    siemensGroup.GroupName = gp.Cgname;
                                    siemensGroup.Length = gp.Cglength;
                                    siemensGroup.IsActive = gp.Isenable == 1;
                                    siemensGroup.Start = gp.Startaddress;

                                    //遍历通信组中的变量
                                    //得到每个变量的属性
                                    foreach (var variable in gp.VarList)
                                    {
                                        SiemensVariable siemensVariable = new SiemensVariable();
                                        siemensVariable.VarName = variable.Variablename;
                                        siemensVariable.VarType = variable.Datatype;
                                        siemensVariable.Start = variable.Startaddress;
                                        siemensVariable.Comments = variable.Comments;

                                        siemensVariable.Scale =Convert.ToSingle(variable.Scale);
                                        siemensVariable.Offset =Convert.ToSingle(variable.Offsetorlength);
                                        //判断是DB存储区，还是常规的I,Q,M存储区
                                        siemensVariable.VarAddress = GetSiemensAddress(gp.Startaddress, variable.Startaddress);

                                        siemensVariable.ArchiveEnable = variable.Isfile;
                                        ///判断最大值报警是否启用
                                        siemensVariable.HighAlarmEnable = variable.Ismaxalarm;

                                        if (siemensVariable.HighAlarmEnable)
                                        {
                                            siemensVariable.HighAlarmValue = Convert.ToSingle(variable.Alarmmax);
                                            siemensVariable.HighAlarmNote = variable.AlarmMaxNode;
                                        }
                                        //判断最小值报警
                                        siemensVariable.LowAlarmEnable = variable.Isminalarm;

                                        if (siemensVariable.LowAlarmEnable)
                                        {
                                            siemensVariable.LowAlarmValue = Convert.ToSingle(variable.Alarmmin);
                                            siemensVariable.LowAlarmNote = variable.AlarmMinNode;
                                        }
                                        //西门子S7通信组变量
                                        siemensGroup.VarList.Add(siemensVariable);
                                    }
                                    //西门子S7通信配置的通信组
                                    siemensDevice.GroupList.Add(siemensGroup);
                                }
                                //西门子S7配置
                                project.SiemensList.Add(siemensDevice);

                                break;

                            case "三菱A1E":
                            case "三菱MC":
                                MelsecDevice melsecDevice = new MelsecDevice();
                                melsecDevice.DeviceName = eq.EquipmentName;
                                melsecDevice.Ipaddress = eq.Ipaddress;
                                melsecDevice.Port = Convert.ToInt32(eq.Portno);
                                melsecDevice.ProtocolType = eq.PtypeName;

                                //用描述来表示MelsecType
                                if (Enum.IsDefined(typeof(MelsecType), eq.Comments))
                                {
                                    melsecDevice.MelsecType = (MelsecType)Enum.Parse(typeof(MelsecType), eq.Comments);
                                }

                                melsecDevice.IsActive = eq.Isenable == 1;

                                foreach (var gp in eq.CGroupList)
                                {
                                    MelsecGroup melsecGroup = new MelsecGroup();
                                    melsecGroup.GroupName = gp.Cgname;
                                    melsecGroup.Length = gp.Cglength;
                                    melsecGroup.IsActive = gp.Isenable == 1;
                                    melsecGroup.Start = gp.Startaddress;

                                    foreach (var variable in gp.VarList)
                                    {
                                        MelsecVariable melsecVariable = new MelsecVariable();
                                        melsecVariable.VarName = variable.Variablename;
                                        melsecVariable.VarType = variable.Datatype;
                                        melsecVariable.Start = variable.Startaddress;
                                        melsecVariable.Comments = variable.Comments;


                                        melsecVariable.Scale =Convert.ToSingle(variable.Scale);
                                        melsecVariable.Offset =Convert.ToSingle(variable.Offsetorlength);

                                        melsecVariable.VarAddress = GetMelsecAddress(gp.Startaddress, variable.Startaddress);

                                        melsecVariable.ArchiveEnable = variable.Isfile;

                                        melsecVariable.HighAlarmEnable = variable.Ismaxalarm;

                                        if (melsecVariable.HighAlarmEnable)
                                        {
                                            melsecVariable.HighAlarmValue = Convert.ToSingle(variable.Alarmmax);
                                            melsecVariable.HighAlarmNote = variable.AlarmMaxNode;
                                        }

                                        melsecVariable.LowAlarmEnable = variable.Isminalarm;

                                        if (melsecVariable.LowAlarmEnable)
                                        {
                                            melsecVariable.LowAlarmValue = Convert.ToSingle(variable.Alarmmin);
                                            melsecVariable.LowAlarmNote = variable.AlarmMinNode;
                                        }

                                        melsecGroup.VarList.Add(melsecVariable);
                                    }

                                    melsecDevice.GroupList.Add(melsecGroup);
                                }

                                project.MelsecList.Add(melsecDevice);

                                break;

                            case "三菱FXSerial":
                                MelsecFXSerialDevice melsecFXSerialDevice = new MelsecFXSerialDevice();
                                melsecFXSerialDevice.DeviceName = eq.EquipmentName;
                                melsecFXSerialDevice.PortName = eq.Serialno;
                                melsecFXSerialDevice.Baudrate = eq.Baudrate;
                                melsecFXSerialDevice.Parity = (Parity)Enum.Parse(typeof(Parity), eq.Paritybit);
                                melsecFXSerialDevice.Databits = eq.Databit;
                                melsecFXSerialDevice.Stopbits = (StopBits)(eq.Stopbit);
                                melsecFXSerialDevice.IsActive = eq.Isenable == 1;

                                foreach (var gp in eq.CGroupList)
                                {
                                    MelsecFXSerialGroup melsecFXSerialGroup = new MelsecFXSerialGroup();
                                    melsecFXSerialGroup.GroupName = gp.Cgname;
                                    melsecFXSerialGroup.Length = gp.Cglength;
                                    melsecFXSerialGroup.IsActive = gp.Isenable == 1;
                                    melsecFXSerialGroup.Start = gp.Startaddress;

                                    foreach (var variable in gp.VarList)
                                    {
                                        MelsecFXSerialVariable melsecFXSerialVariable = new MelsecFXSerialVariable();
                                        melsecFXSerialVariable.VarName = variable.Variablename;
                                        melsecFXSerialVariable.VarType = variable.Datatype;
                                        melsecFXSerialVariable.Start = variable.Startaddress;
                                        melsecFXSerialVariable.Comments = variable.Comments;

                                        melsecFXSerialVariable.Scale = Convert.ToSingle(variable.Scale);
                                        melsecFXSerialVariable.Offset = Convert.ToSingle(variable.Offsetorlength);

                                        melsecFXSerialVariable.VarAddress = GetMelsecAddress(gp.Startaddress, variable.Startaddress);

                                        melsecFXSerialVariable.ArchiveEnable = variable.Isfile;

                                        melsecFXSerialVariable.HighAlarmEnable = variable.Ismaxalarm;

                                        if (melsecFXSerialVariable.HighAlarmEnable)
                                        {
                                            melsecFXSerialVariable.HighAlarmValue = Convert.ToSingle(variable.Alarmmax);
                                            melsecFXSerialVariable.HighAlarmNote = variable.AlarmMaxNode;
                                        }

                                        melsecFXSerialVariable.LowAlarmEnable = variable.Isminalarm;

                                        if (melsecFXSerialVariable.LowAlarmEnable)
                                        {
                                            melsecFXSerialVariable.LowAlarmValue = Convert.ToSingle(variable.Alarmmin);
                                            melsecFXSerialVariable.LowAlarmNote = variable.AlarmMinNode;
                                        }

                                        melsecFXSerialGroup.VarList.Add(melsecFXSerialVariable);
                                    }

                                    melsecFXSerialDevice.GroupList.Add(melsecFXSerialGroup);
                                }

                                project.MelsecFXSerialList.Add(melsecFXSerialDevice);

                                break;

                            case "欧姆龙FinsTCP":
                                OmronDevice omronDevice = new OmronDevice();
                                omronDevice.DeviceName = eq.EquipmentName;
                                omronDevice.Ipaddress = eq.Ipaddress;
                                omronDevice.Port = Convert.ToInt32(eq.Portno);

                                omronDevice.IsActive = eq.Isenable == 1;

                                foreach (var gp in eq.CGroupList)
                                {
                                    OmronGroup omronGroup = new OmronGroup();
                                    omronGroup.GroupName = gp.Cgname;
                                    omronGroup.Length = gp.Cglength;
                                    omronGroup.IsActive = gp.Isenable == 1;
                                    omronGroup.Start = gp.Startaddress;

                                    foreach (var variable in gp.VarList)
                                    {
                                        OmronVariable omronVariable = new OmronVariable();
                                        omronVariable.VarName = variable.Variablename;
                                        omronVariable.VarType = variable.Datatype;
                                        omronVariable.Start = variable.Startaddress;
                                        omronVariable.Comments = variable.Comments;

                                        omronVariable.Scale = Convert.ToSingle(variable.Offsetorlength);
                                        omronVariable.Offset =Convert.ToSingle(variable.Offsetorlength);

                                        omronVariable.VarAddress = GetOmronAddress(gp.Startaddress, variable.Startaddress);

                                        omronVariable.ArchiveEnable = variable.Isfile;

                                        omronVariable.HighAlarmEnable = variable.Ismaxalarm;

                                        if (omronVariable.HighAlarmEnable)
                                        {
                                            omronVariable.HighAlarmValue = Convert.ToSingle(variable.Alarmmax);
                                            omronVariable.HighAlarmNote = variable.AlarmMaxNode;
                                        }

                                        omronVariable.LowAlarmEnable = variable.Isminalarm;

                                        if (omronVariable.LowAlarmEnable)
                                        {
                                            omronVariable.LowAlarmValue = Convert.ToSingle(variable.Alarmmin);
                                            omronVariable.LowAlarmNote = variable.AlarmMinNode;
                                        }

                                        omronGroup.VarList.Add(omronVariable);
                                    }

                                    omronDevice.GroupList.Add(omronGroup);
                                }

                                project.OmronList.Add(omronDevice);

                                break;

                            case "欧姆龙Hostlink":
                                OmronHostlinkDevice omronHostlinkDevice = new OmronHostlinkDevice();
                                omronHostlinkDevice.DeviceName = eq.EquipmentName;
                                //端口号
                                omronHostlinkDevice.PortName = eq.Serialno;
                                //波特率
                                omronHostlinkDevice.Baudrate = eq.Baudrate;
                                //校验位
                                omronHostlinkDevice.Parity = (Parity)Enum.Parse(typeof(Parity), eq.Paritybit);
                                //数据位
                                omronHostlinkDevice.Databits = eq.Databit;
                                //停止位
                                omronHostlinkDevice.Stopbits = (StopBits)(eq.Stopbit);

                                //用描述表示额外的三个通信参数
                                //解析不出来，也就是没有填写对应的通信参数默认位0
                                if (eq.Comments.Contains('.'))
                                {
                                    string[] values = eq.Comments.Split('.');

                                    if (values.Length == 3)
                                    {
                                        //欧姆龙Hostlink的通信，单元号，PC单元号，响应时间
                                        omronHostlinkDevice.UnitNo = Convert.ToByte(values[0]);
                                        omronHostlinkDevice.SA2 = Convert.ToByte(values[1]);
                                        omronHostlinkDevice.ResponseWaitTime = Convert.ToByte(values[2]);
                                    }
                                }

                                omronHostlinkDevice.IsActive = eq.Isenable == 1;

                                foreach (var gp in eq.CGroupList)
                                {
                                    OmronHostlinkGroup omronHostlinkGroup = new OmronHostlinkGroup();
                                    omronHostlinkGroup.GroupName = gp.Cgname;
                                    omronHostlinkGroup.Length = gp.Cglength;
                                    omronHostlinkGroup.IsActive = gp.Isenable == 1;
                                    omronHostlinkGroup.Start = gp.Startaddress;

                                    foreach (var variable in gp.VarList)
                                    {
                                        OmronHostlinkVariable omronHostlinkVariable = new OmronHostlinkVariable();
                                        omronHostlinkVariable.VarName = variable.Variablename;
                                        omronHostlinkVariable.VarType = variable.Datatype;
                                        omronHostlinkVariable.Start = variable.Startaddress;
                                        omronHostlinkVariable.Comments = variable.Comments;

                                        omronHostlinkVariable.Scale =Convert.ToSingle(variable.Scale);
                                        omronHostlinkVariable.Offset = Convert.ToSingle(variable.Offsetorlength);

                                        omronHostlinkVariable.VarAddress = GetOmronAddress(gp.Startaddress, variable.Startaddress);

                                        omronHostlinkVariable.ArchiveEnable = variable.Isfile;

                                        omronHostlinkVariable.HighAlarmEnable = variable.Ismaxalarm;

                                        if (omronHostlinkVariable.HighAlarmEnable)
                                        {
                                            omronHostlinkVariable.HighAlarmValue = Convert.ToSingle(variable.Alarmmax);
                                            omronHostlinkVariable.HighAlarmNote = variable.AlarmMaxNode;
                                        }

                                        omronHostlinkVariable.LowAlarmEnable = variable.Isminalarm;

                                        if (omronHostlinkVariable.LowAlarmEnable)
                                        {
                                            omronHostlinkVariable.LowAlarmValue = Convert.ToSingle(variable.Alarmmin);
                                            omronHostlinkVariable.LowAlarmNote = variable.AlarmMinNode;
                                        }

                                        omronHostlinkGroup.VarList.Add(omronHostlinkVariable);
                                    }

                                    omronHostlinkDevice.GroupList.Add(omronHostlinkGroup);
                                }

                                project.OmronHostlinkList.Add(omronHostlinkDevice);

                                break;

                            case "ModbusRTU":
                                ModbusRTUDevice modbusRTUDevice = new ModbusRTUDevice();
                                modbusRTUDevice.DeviceName = eq.EquipmentName;
                                modbusRTUDevice.PortName = eq.Serialno;
                                modbusRTUDevice.Baudrate = eq.Baudrate;
                                modbusRTUDevice.Parity = (Parity)Enum.Parse(typeof(Parity), eq.Paritybit);
                                modbusRTUDevice.Databits = eq.Databit;
                                modbusRTUDevice.Stopbits = (StopBits)(eq.Stopbit);

                                //用描述来表示是否为短地址
                                modbusRTUDevice.IsShortAddress = eq.Comments.ToLower() != "false";

                                modbusRTUDevice.IsActive = eq.Isenable == 1;

                                foreach (var gp in eq.CGroupList)
                                {
                                    ModbusRTUGroup modbusRTUGroup = new ModbusRTUGroup();
                                    modbusRTUGroup.GroupName = gp.Cgname;
                                    modbusRTUGroup.Length = gp.Cglength;
                                    modbusRTUGroup.IsActive = gp.Isenable == 1;
                                    modbusRTUGroup.Start = gp.Startaddress;

                                    foreach (var variable in gp.VarList)
                                    {
                                        ModbusRTUVariable modbusRTUVariable = new ModbusRTUVariable();
                                        modbusRTUVariable.VarName = variable.Variablename;
                                        modbusRTUVariable.VarType = variable.Datatype;
                                        modbusRTUVariable.Start = variable.Startaddress;
                                        modbusRTUVariable.Comments = variable.Comments;

                                        modbusRTUVariable.Scale =Convert.ToSingle(variable.Scale);
                                        modbusRTUVariable.Offset = Convert.ToSingle(variable.Offsetorlength);

                                        modbusRTUVariable.VarAddress = GetModbusAddress(gp.Startaddress, variable.Startaddress, modbusRTUDevice.IsShortAddress);

                                        modbusRTUVariable.ArchiveEnable = variable.Isfile;

                                        modbusRTUVariable.HighAlarmEnable = variable.Ismaxalarm;

                                        if (modbusRTUVariable.HighAlarmEnable)
                                        {
                                            modbusRTUVariable.HighAlarmValue = Convert.ToSingle(variable.Alarmmax);
                                            modbusRTUVariable.HighAlarmNote = variable.AlarmMaxNode;
                                        }

                                        modbusRTUVariable.LowAlarmEnable = variable.Isminalarm;

                                        if (modbusRTUVariable.LowAlarmEnable)
                                        {
                                            modbusRTUVariable.LowAlarmValue = Convert.ToSingle(variable.Alarmmin);
                                            modbusRTUVariable.LowAlarmNote = variable.AlarmMinNode;
                                        }

                                        modbusRTUGroup.VarList.Add(modbusRTUVariable);
                                    }

                                    modbusRTUDevice.GroupList.Add(modbusRTUGroup);
                                }

                                project.ModbusRTUList.Add(modbusRTUDevice);

                                break;

                            case "ModbusASCII":
                                ModbusASCIIDevice modbusASCIIDevice = new ModbusASCIIDevice();
                                modbusASCIIDevice.DeviceName = eq.EquipmentName;
                                modbusASCIIDevice.PortName = eq.Serialno;
                                modbusASCIIDevice.Baudrate = eq.Baudrate;
                                modbusASCIIDevice.Parity = (Parity)Enum.Parse(typeof(Parity), eq.Paritybit);
                                modbusASCIIDevice.Databits = eq.Databit;
                                modbusASCIIDevice.Stopbits = (StopBits)(eq.Stopbit);

                                //用描述来表示是否为短地址
                                modbusASCIIDevice.IsShortAddress = eq.Comments.ToLower() != "false";

                                modbusASCIIDevice.IsActive = eq.Isenable == 1;

                                foreach (var gp in eq.CGroupList)
                                {
                                    ModbusASCIIGroup modbusASCIIGroup = new ModbusASCIIGroup();
                                    modbusASCIIGroup.GroupName = gp.Cgname;
                                    modbusASCIIGroup.Length = gp.Cglength;
                                    modbusASCIIGroup.IsActive = gp.Isenable == 1;
                                    modbusASCIIGroup.Start = gp.Startaddress;

                                    foreach (var variable in gp.VarList)
                                    {
                                        ModbusASCIIVariable modbusASCIIVariable = new ModbusASCIIVariable();
                                        modbusASCIIVariable.VarName = variable.Variablename;
                                        modbusASCIIVariable.VarType = variable.Datatype;
                                        modbusASCIIVariable.Start = variable.Startaddress;
                                        modbusASCIIVariable.Comments = variable.Comments;


                                        modbusASCIIVariable.Scale =Convert.ToSingle(variable.Scale);
                                        modbusASCIIVariable.Offset = Convert.ToSingle(variable.Offsetorlength);

                                        modbusASCIIVariable.VarAddress = GetModbusAddress(gp.Startaddress, variable.Startaddress, modbusASCIIDevice.IsShortAddress);

                                        modbusASCIIVariable.ArchiveEnable = variable.Isfile;

                                        modbusASCIIVariable.HighAlarmEnable = variable.Ismaxalarm;

                                        if (modbusASCIIVariable.HighAlarmEnable)
                                        {
                                            modbusASCIIVariable.HighAlarmValue = Convert.ToSingle(variable.Alarmmax);
                                            modbusASCIIVariable.HighAlarmNote = variable.AlarmMaxNode;
                                        }

                                        modbusASCIIVariable.LowAlarmEnable = variable.Isminalarm;

                                        if (modbusASCIIVariable.LowAlarmEnable)
                                        {
                                            modbusASCIIVariable.LowAlarmValue = Convert.ToSingle(variable.Alarmmin);
                                            modbusASCIIVariable.LowAlarmNote = variable.AlarmMinNode;
                                        }

                                        modbusASCIIGroup.VarList.Add(modbusASCIIVariable);
                                    }

                                    modbusASCIIDevice.GroupList.Add(modbusASCIIGroup);
                                }

                                project.ModbusASCIIList.Add(modbusASCIIDevice);

                                break;

                            case "ModbusTCP":
                                ModbusTCPDevice modbusTCPDevice = new ModbusTCPDevice();
                                modbusTCPDevice.DeviceName = eq.EquipmentName;
                                modbusTCPDevice.Ipaddress = eq.Ipaddress;
                                modbusTCPDevice.Port = Convert.ToInt32(eq.Portno);

                                //用描述来表示是否为短地址
                                modbusTCPDevice.IsShortAddress = eq.Comments.ToLower() != "false";

                                modbusTCPDevice.IsActive = eq.Isenable == 1;

                                foreach (var gp in eq.CGroupList)
                                {
                                    ModbusTCPGroup modbusTCPGroup = new ModbusTCPGroup();
                                    modbusTCPGroup.GroupName = gp.Cgname;
                                    modbusTCPGroup.Length = gp.Cglength;
                                    modbusTCPGroup.IsActive = gp.Isenable == 1;
                                    modbusTCPGroup.Start = gp.Startaddress;

                                    foreach (var variable in gp.VarList)
                                    {
                                        ModbusTCPVariable modbusTCPVariable = new ModbusTCPVariable();
                                        modbusTCPVariable.VarName = variable.Variablename;
                                        modbusTCPVariable.VarType = variable.Datatype;
                                        modbusTCPVariable.Start = variable.Startaddress;
                                        modbusTCPVariable.Comments = variable.Comments;

                                        modbusTCPVariable.Scale = Convert.ToSingle(variable.Scale);
                                        modbusTCPVariable.Offset = Convert.ToSingle(variable.Offsetorlength);

                                        modbusTCPVariable.VarAddress = GetModbusAddress(gp.Startaddress, variable.Startaddress, modbusTCPDevice.IsShortAddress);

                                        modbusTCPVariable.ArchiveEnable = variable.Isfile;

                                        modbusTCPVariable.HighAlarmEnable = variable.Ismaxalarm;

                                        if (modbusTCPVariable.HighAlarmEnable)
                                        {
                                            modbusTCPVariable.HighAlarmValue = Convert.ToSingle(variable.Alarmmax);
                                            modbusTCPVariable.HighAlarmNote = variable.AlarmMaxNode;
                                        }

                                        modbusTCPVariable.LowAlarmEnable = variable.Isminalarm;

                                        if (modbusTCPVariable.LowAlarmEnable)
                                        {
                                            modbusTCPVariable.LowAlarmValue = Convert.ToSingle(variable.Alarmmin);
                                            modbusTCPVariable.LowAlarmNote = variable.AlarmMinNode;
                                        }

                                        modbusTCPGroup.VarList.Add(modbusTCPVariable);
                                    }

                                    modbusTCPDevice.GroupList.Add(modbusTCPGroup);
                                }

                                project.ModbusTCPList.Add(modbusTCPDevice);

                                break;

                            case "ModbusRTUOverTCP":
                                ModbusRTUOverTCPDevice modbusRTUOverTCPDevice = new ModbusRTUOverTCPDevice();
                                modbusRTUOverTCPDevice.DeviceName = eq.EquipmentName;
                                modbusRTUOverTCPDevice.Ipaddress = eq.Ipaddress;
                                modbusRTUOverTCPDevice.Port = Convert.ToInt32(eq.Portno);

                                //用描述来表示是否为短地址
                                modbusRTUOverTCPDevice.IsShortAddress = eq.Comments.ToLower() != "false";

                                modbusRTUOverTCPDevice.IsActive = eq.Isenable == 1;

                                foreach (var gp in eq.CGroupList)
                                {
                                    ModbusRTUOverTCPGroup modbusRTUOverTCPGroup = new ModbusRTUOverTCPGroup();
                                    modbusRTUOverTCPGroup.GroupName = gp.Cgname;
                                    modbusRTUOverTCPGroup.Length = gp.Cglength;
                                    modbusRTUOverTCPGroup.IsActive = gp.Isenable == 1;
                                    modbusRTUOverTCPGroup.Start = gp.Startaddress;

                                    foreach (var variable in gp.VarList)
                                    {
                                        ModbusRTUOverTCPVariable modbusRTUOverTCPVariable = new ModbusRTUOverTCPVariable();
                                        modbusRTUOverTCPVariable.VarName = variable.Variablename;
                                        modbusRTUOverTCPVariable.VarType = variable.Datatype;
                                        modbusRTUOverTCPVariable.Start = variable.Startaddress;
                                        modbusRTUOverTCPVariable.Comments = variable.Comments;

                                        modbusRTUOverTCPVariable.Scale =Convert.ToSingle(variable.Scale);
                                        modbusRTUOverTCPVariable.Offset =Convert.ToSingle(variable.Offsetorlength);

                                        modbusRTUOverTCPVariable.VarAddress = GetModbusAddress(gp.Startaddress, variable.Startaddress, modbusRTUOverTCPDevice.IsShortAddress);

                                        modbusRTUOverTCPVariable.ArchiveEnable = variable.Isfile;

                                        modbusRTUOverTCPVariable.HighAlarmEnable = variable.Ismaxalarm;

                                        if (modbusRTUOverTCPVariable.HighAlarmEnable)
                                        {
                                            modbusRTUOverTCPVariable.HighAlarmValue = Convert.ToSingle(variable.Alarmmax);
                                            modbusRTUOverTCPVariable.HighAlarmNote = variable.AlarmMaxNode;
                                        }

                                        modbusRTUOverTCPVariable.LowAlarmEnable = variable.Isminalarm;

                                        if (modbusRTUOverTCPVariable.LowAlarmEnable)
                                        {
                                            modbusRTUOverTCPVariable.LowAlarmValue = Convert.ToSingle(variable.Alarmmin);
                                            modbusRTUOverTCPVariable.LowAlarmNote = variable.AlarmMinNode;
                                        }

                                        modbusRTUOverTCPGroup.VarList.Add(modbusRTUOverTCPVariable);
                                    }

                                    modbusRTUOverTCPDevice.GroupList.Add(modbusRTUOverTCPGroup);
                                }

                                project.ModbusRTUOverTCPList.Add(modbusRTUOverTCPDevice);

                                break;

                            case "OPCDA":

                                OPCDADevice oPCDADevice = new OPCDADevice();
                                oPCDADevice.ServerNode = eq.Opcnodename;
                                oPCDADevice.ServerName = eq.Opcservername;

                                oPCDADevice.IsActive = eq.Isenable == 1;

                                foreach (var gp in eq.CGroupList)
                                {
                                    OPCDAGroup oPCDAGroup = new OPCDAGroup();

                                    oPCDAGroup.GroupName = gp.Cgname;
                                    oPCDAGroup.IsActive = gp.Isenable == 1;

                                    foreach (var variable in gp.VarList)
                                    {
                                        OPCDAVariable oPCDAVariable = new OPCDAVariable();

                                        oPCDAVariable.VarName = variable.Variablename;
                                        oPCDAVariable.VarType = variable.Datatype;
                                        oPCDAVariable.Comments = variable.Comments;
                                        oPCDAVariable.VarAddress = variable.Startaddress;

                                        oPCDAVariable.Scale =Convert.ToSingle(variable.Scale);
                                        oPCDAVariable.Offset =Convert.ToSingle(variable.Offsetorlength);

                                        oPCDAVariable.ArchiveEnable = variable.Isfile;

                                        oPCDAVariable.HighAlarmEnable = variable.Ismaxalarm;

                                        if (oPCDAVariable.HighAlarmEnable)
                                        {
                                            oPCDAVariable.HighAlarmValue = Convert.ToSingle(variable.Alarmmax);
                                            oPCDAVariable.HighAlarmNote = variable.AlarmMaxNode;
                                        }

                                        oPCDAVariable.LowAlarmEnable = variable.Isminalarm;

                                        if (oPCDAVariable.LowAlarmEnable)
                                        {
                                            oPCDAVariable.LowAlarmValue = Convert.ToSingle(variable.Alarmmin);
                                            oPCDAVariable.LowAlarmNote = variable.AlarmMinNode;
                                        }

                                        oPCDAGroup.VarList.Add(oPCDAVariable);
                                    }

                                    oPCDADevice.GroupList.Add(oPCDAGroup);
                                }

                                project.OPCDAList.Add(oPCDADevice);
                                break;

                            case "OPCUA":

                                OPCUADevice oPCUADevice = new OPCUADevice();
                                oPCUADevice.ServerUrl = eq.Opcnodename;

                                oPCUADevice.IsActive = eq.Isenable == 1;

                                foreach (var gp in eq.CGroupList)
                                {
                                    OPCUAGroup oPCUAGroup = new OPCUAGroup();

                                    oPCUAGroup.GroupName = gp.Cgname;
                                    oPCUAGroup.IsActive = gp.Isenable == 1;

                                    foreach (var variable in gp.VarList)
                                    {
                                        OPCUAVariable oPCUAVariable = new OPCUAVariable();

                                        oPCUAVariable.VarName = variable.Variablename;
                                        oPCUAVariable.VarType = variable.Datatype;
                                        oPCUAVariable.Comments = variable.Comments;
                                        oPCUAVariable.VarAddress = variable.Startaddress;

                                        oPCUAVariable.Scale = Convert.ToSingle(variable.Scale);
                                        oPCUAVariable.Offset = Convert.ToSingle(variable.Offsetorlength);

                                        oPCUAVariable.ArchiveEnable = variable.Isfile;

                                        oPCUAVariable.HighAlarmEnable = variable.Ismaxalarm;

                                        if (oPCUAVariable.HighAlarmEnable)
                                        {
                                            oPCUAVariable.HighAlarmValue = Convert.ToSingle(variable.Alarmmax);
                                            oPCUAVariable.HighAlarmNote = variable.AlarmMaxNode;
                                        }

                                        oPCUAVariable.LowAlarmEnable = variable.Isminalarm;

                                        if (oPCUAVariable.LowAlarmEnable)
                                        {
                                            oPCUAVariable.LowAlarmValue = Convert.ToSingle(variable.Alarmmin);
                                            oPCUAVariable.LowAlarmNote = variable.AlarmMinNode;
                                        }

                                        oPCUAGroup.VarList.Add(oPCUAVariable);
                                    }

                                    oPCUADevice.GroupList.Add(oPCUAGroup);
                                }

                                project.OPCUAList.Add(oPCUADevice);

                                break;

                            default: break;
                        }
                    }

                }
                else
                {
                    continue;
                }
                result.Add(project);
            }

            return result;
        }

        /// <summary>
        /// DB1.0  100     10   DB1.10
        /// M0   100      10    M10
        /// 解析获取西门子PLC地址
        /// </summary>
        /// <param name="gpStart">通信组地址</param>
        /// <param name="varStart">变量地址</param>
        /// <returns>返回通信的地址</returns>
        private string GetSiemensAddress(string gpStart, string varStart)
        {
            //DB存储区
            if (gpStart.Substring(0, 2).ToUpper() == "DB")
            {
                if (gpStart.Contains('.'))
                {

                    return gpStart.Substring(0, gpStart.IndexOf('.')) + "." + varStart;
                }
                else
                {
                    return string.Empty;
                }
            }
            else
            {
                return gpStart.Substring(0, 1) + "." + varStart;
            }
        }

        /// <summary>
        /// 三菱
        /// </summary>
        /// <param name="gpStart">通信组地址</param>
        /// <param name="varStart">变量地址</param>
        /// <returns></returns>
        private string GetMelsecAddress(string gpStart, string varStart)
        {
            return gpStart.Substring(0, 1) + varStart;
        }

        /// <summary>
        /// 欧姆龙
        /// </summary>
        /// <param name="gpStart">通信组地址</param>
        /// <param name="varStart">变量地址</param>
        /// <returns></returns>
        private string GetOmronAddress(string gpStart, string varStart)
        {
            return gpStart.Substring(0, 1) + varStart;
        }

        /// <summary>
        /// Modbus
        /// </summary>
        /// <param name="gpStart">通信组地址</param>
        /// <param name="varStart">变量地址</param>
        /// <param name="isShortAddress">是否是短地址</param>
        /// <returns></returns>
        private string GetModbusAddress(string gpStart, string varStart, bool isShortAddress)
        {
            if (gpStart.Contains('.'))
            {
                string[] adds = gpStart.Split('.');

                if (adds.Length == 2)
                {
                    switch (adds[1][0].ToString())
                    {
                        case "4": return isShortAddress ? adds[0] + "." + (40001 + Convert.ToSingle(varStart)).ToString() : adds[0] + "." + (400001 + Convert.ToSingle(varStart)).ToString();
                        case "3": return isShortAddress ? adds[0] + "." + (30001 + Convert.ToSingle(varStart)).ToString() : adds[0] + "." + (300001 + Convert.ToSingle(varStart)).ToString();
                        case "1": return isShortAddress ? adds[0] + "." + (10001 + Convert.ToSingle(varStart)).ToString() : adds[0] + "." + (100001 + Convert.ToSingle(varStart)).ToString();
                        case "0": return isShortAddress ? adds[0] + "." + (1 + Convert.ToSingle(varStart)).ToString() : adds[0] + "." + (1 + Convert.ToSingle(varStart)).ToString();
                        default:
                            break;
                    }

                }
            }
            return String.Empty;
        }
    }
}
