using System;
using System.Threading.Tasks;
using LucidX.RequestModels;
using LucidX.ResponseModels;
using LucidX.Constants;
using System.Net.Http;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace LucidX
{
    public class WebServiceMethods
	{
		public async static Task<FinalResponse> Login(string username, string password) {
			try
			{
                LoginAPIParams param = new LoginAPIParams
                {
                    userID = username,
                    strPwd = password,
                    connectionName = WebserviceConstants.CONNECTION_NAME

                };
               
                FinalResponse response = await Webservices.WebServiceHandler.GetWebserviceResult(WebserviceConstants.LOGIN_URL,
                    HttpMethod.Post, param) as FinalResponse;
                return response;
			}
			catch (Exception ex){
				return null;
			}
		}

        public async static Task<Dictionary<string, int>> EmailCount(string userId)
        {
            try
            {
              
                EmailCountsAPIParams param= new EmailCountsAPIParams
                {
                    intUserID = userId,                  
                    connectionName = WebserviceConstants.CONNECTION_NAME

                };

                var response = await Webservices.WebServiceHandler.GetWebserviceResult(WebserviceConstants.EMAIL_COUNT_URL,
                    HttpMethod.Post, param) as FinalResponse;

                DataSet resultIds = response.ResultDs;

                Dictionary<string, int> countDictionary = new Dictionary<string, int>();

                string key = null;
                int value = 0;

                foreach (DataTable dt in resultIds.Tables)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        foreach (DataColumn dc in dt.Columns)
                        {
                          
                            if (dc.ColumnName == "eMailTypeName")
                            {
                                key = dr[dc].ToString();
                            }
                            if (dc.ColumnName == "Column1")
                            {
                                value = Convert.ToInt32(dr[dc].ToString());
                            }
                        }
                        countDictionary.Add(key, value);
                    }
                }
            
                return countDictionary;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async static Task<FinalResponse> MarkReadEmail(string mailId)
        {
            try
            {

                MarkReadEmailApiParams param = new MarkReadEmailApiParams
                {
                    mailId = mailId,
                    read= true,
                    connectionName = WebserviceConstants.CONNECTION_NAME

                };

                var response = await Webservices.WebServiceHandler.GetWebserviceResult(WebserviceConstants.MARK_READ_EMAIL_URL,
                    HttpMethod.Post, param) as FinalResponse;

                return response as FinalResponse;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async static Task<List<EmailResponse>> InboxEmails(string userId)
        {
            try
            {

                InboxEmailApiParams param = new InboxEmailApiParams
                {
                    mailCount = 10,
                    mailTypeId= 1,
                    filterIndex=0,
                    filterEmail="",
                    blnShowblank=false,
                    intUserID = userId,
                    connectionName = WebserviceConstants.CONNECTION_NAME

                };


                var response = await Webservices.WebServiceHandler.GetWebserviceResult(WebserviceConstants.SHOW_INBOX_EMAILS_URL,
                    HttpMethod.Post, param) as FinalResponse;

                DataSet resultIds = response.ResultDs;

                List<EmailResponse> emailList = null;
                foreach (DataTable dt in resultIds.Tables)
                {

                    emailList = (from DataRow dr in dt.Rows
                                   select new EmailResponse()
                                   {
                                       MailId = Convert.ToInt32(dr["MailId"]),
                                       DisplayDate = dr["DisplayDate"].ToString(),
                                       myGroup = dr["myGroup"].ToString(),
                                       Received = dr["Received"].ToString(),
                                       FolderName = dr["FolderName"].ToString(),
                                       AccountCode = dr["AccountCode"].ToString(),
                                       Sender = dr["Sender"].ToString(),
                                       SenderName = dr["SenderName"].ToString(),
                                       Subject = dr["Subject"].ToString(),
                                       eMailTypeId = Convert.ToInt32(dr["eMailTypeId"]),
                                       Unread = Convert.ToBoolean(dr["Unread"]),
                                       Important = Convert.ToBoolean(dr["Important"]),
                                       Attachment = Convert.ToInt32(dr["Attachment"]),
                                       SenderEmail = dr["SenderEmail"].ToString()
                                   }).ToList();

                }

                return emailList;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private static List<T> ConvertDataTable<T>(DataTable dt)
        {
            List<T> data = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                T item = GetItem<T>(row);
                data.Add(item);
            }
            return data;
        }
        private static T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name == column.ColumnName)
                        pro.SetValue(obj, dr[column.ColumnName], null);
                    else
                        continue;
                }
            }
            return obj;
        }



    }
}
