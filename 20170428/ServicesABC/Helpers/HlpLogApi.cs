using Modelo.Seguridad;
using System;
using System.ComponentModel;
using System.Reflection;

namespace ServicesABC.Helpers
{
    public static class HlpLog
    {         
        public static void Warning(eService _service,String _username,CodeMessages Code)
        {
            try
            {
                FinancyContext db = new FinancyContext();
                LogServiceABC dataLogApi = new LogServiceABC();
                dataLogApi.Service = _service;
                dataLogApi.UserName = _username;
                dataLogApi.DateTransaction = DateTime.Now; ;
                dataLogApi.Type = TypeLog.Warning.ToString();
                dataLogApi.Code = CodeString((int)Code);
                dataLogApi.Message = HlpLog.GetEnumDescription(Code);
                dataLogApi.StackTrace = "";
                db.LogServiceABC.Add(dataLogApi);
                db.SaveChanges();
            }
            catch(Exception ex){
                ex.ToString();
            }
        }
        public static void Warning(eService _service, String _username, CodeMessages Code,String Message)
        {
            try
            {
                FinancyContext db = new FinancyContext();
                LogServiceABC dataLogApi = new LogServiceABC();
                dataLogApi.Service = _service;
                dataLogApi.UserName = _username;
                dataLogApi.DateTransaction = DateTime.Now; ;
                dataLogApi.Type = TypeLog.Warning.ToString();
                dataLogApi.Code = CodeString((int)Code);
                dataLogApi.Message = Message;
                dataLogApi.StackTrace = "";
                db.LogServiceABC.Add(dataLogApi);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        public static void Error(eService _service, String _username, CodeMessages Code, Exception exception)
        {
            FinancyContext db = new FinancyContext();
            LogServiceABC dataLogApi = new LogServiceABC();
            try
            {
              
                dataLogApi.Service = _service;
                dataLogApi.UserName = _username;
                dataLogApi.DateTransaction = DateTime.Now; ;
                dataLogApi.Type = TypeLog.Error.ToString();
                dataLogApi.Code = CodeString((int)Code);
                dataLogApi.Message = HlpLog.GetEnumDescription(Code);
                dataLogApi.StackTrace = exception.ToString();               
                db.LogServiceABC.Add(dataLogApi);
                db.SaveChanges();
                writeLog(dataLogApi);
                
            }
            catch (Exception ex)
            {
                writeLog(dataLogApi);
                ex.ToString();
            }
        }
        public static void Information(eService _service, String _username, CodeMessages Code,String Message)
        {
            FinancyContext db = new FinancyContext();
            LogServiceABC dataLogApi = new LogServiceABC();
            try
            {
               
                dataLogApi.Service = _service;
                dataLogApi.UserName = _username;
                dataLogApi.DateTransaction = DateTime.Now; ;
                dataLogApi.Type = TypeLog.Information.ToString();
                dataLogApi.Code = CodeString((int)Code);
                dataLogApi.Message = Message;
                dataLogApi.StackTrace = "";
                db.LogServiceABC.Add(dataLogApi);
                db.SaveChanges();
                writeLog(dataLogApi);
            }
            catch (Exception ex)
            {
                writeLog(dataLogApi);
                ex.ToString();
            }
        }
        public static void Information(eService _service, String _username, CodeMessages Code)
        {
            FinancyContext db = new FinancyContext();
            LogServiceABC dataLogApi = new LogServiceABC();
            try
            {
                
                dataLogApi.Service = _service;
                dataLogApi.UserName = _username;
                dataLogApi.DateTransaction = DateTime.Now; ;
                dataLogApi.Type = TypeLog.Information.ToString();
                dataLogApi.Code = CodeString((int)Code);
                dataLogApi.Message = HlpLog.GetEnumDescription(Code); 
                dataLogApi.StackTrace = "";
                db.LogServiceABC.Add(dataLogApi);
                db.SaveChanges();
                writeLog(dataLogApi);
            }
            catch (Exception ex)
            {
                writeLog(dataLogApi);
                ex.ToString();
            }
        }
        public static String CodeString(int Code)
        {
            String mascara="0000";
            return (mascara).Substring(0, mascara.Length - Code.ToString().Length) + Code.ToString();
        }

        public static string GetEnumDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes =
                (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0)
                return attributes[0].Description;
            else
                return value.ToString();
        }

        public static void writeLog(LogServiceABC log){
           /* string pathlLogEvidente = System.Configuration.ConfigurationManager.AppSettings["rutalLogFirmaElectronica"];
            DateTime now=DateTime.Now;
            String dd_mm_aaaa = now.Day.ToString() + "_" + now.Month.ToString() + "_" + now.Year.ToString();
            string nameFile = "Log_Api_Firma_Electronica_" + dd_mm_aaaa;

            if (!Directory.Exists(pathlLogEvidente))
            {
                Directory.CreateDirectory(pathlLogEvidente);
            }
            StreamWriter WriteLogFile = File.AppendText(pathlLogEvidente + nameFile + ".log");
            WriteLogFile.WriteLine("------------------\n");
            WriteLogFile.WriteLine("Service: " + GetEnumDescription(log.Service) + "\n");
            WriteLogFile.WriteLine( "UserName: " + log.UserName + "\n");
            WriteLogFile.WriteLine("DateTransaction: " + log.DateTransaction.ToLongDateString() + " - " + log.DateTransaction.ToLongTimeString() + "\n");
            WriteLogFile.WriteLine( "Type: " + log.Type.ToString() + "\n");
            WriteLogFile.WriteLine( "Code: " + log.Code + "\n");
            WriteLogFile.WriteLine( "Message: " + log.Message + "\n");
            WriteLogFile.WriteLine( "StackTrace: " + log.StackTrace + "\n");            
            WriteLogFile.Close();
          */
        }
    }

      
}