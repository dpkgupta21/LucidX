using System;
using System.Threading.Tasks;
using LucidX.RequestModels;
using LucidX.ResponseModels;
using LucidX.Constants;
using System.Net.Http;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace LucidX.Webservices
{
    public class WebServiceMethods
    {
        public async static Task<LoginResponse> Login(string username, string password)
        {
            try
            {

                LoginAPIParams param = new LoginAPIParams
                {
                    userID = username,
                    strPwd = password,
                    connectionName = WebserviceConstants.CONNECTION_NAME

                };

                FinalResponse response = await WebServiceHandler.GetWebserviceResult(WebserviceConstants.LOGIN_URL,
                    HttpMethod.Post, param) as FinalResponse;
                var responseLst = response.ResultDoc as XmlNode[];
                bool isAuthenticate = false;
                isAuthenticate = Convert.ToBoolean(responseLst.FirstOrDefault(x => x.Name == "isAuthenticate").InnerText);

                LoginResponse loginInfo = null;
                if (isAuthenticate)
                {
                    loginInfo = new LoginResponse();

                    loginInfo.IsAuthenticate = isAuthenticate;
                    XmlNode node = responseLst[4];

                    for (int i = 0; i < node.ChildNodes.Count; i++)
                    {
                        XmlNode childNode = node.ChildNodes[i];
                        if (i == 0)
                        {
                            loginInfo.UserId = childNode.InnerText.ToString();
                        }
                        else if (i == 1)
                        {
                            loginInfo.Name = childNode.InnerText.ToString();
                        }
                        else if (i == 6)
                        {
                            loginInfo.UserEmail = childNode.InnerText.ToString();
                        }
                    }
                }

                return loginInfo;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async static Task<EmailCountResponse> EmailCount(string userId)
        {
            try
            {
                EmailCountsAPIParams param = new EmailCountsAPIParams
                {
                    intUserID = userId,
                    connectionName = WebserviceConstants.CONNECTION_NAME
                };

                var response = await WebServiceHandler.GetWebserviceResult(WebserviceConstants.EMAIL_COUNT_URL,
                    HttpMethod.Post, param) as FinalResponse;

                EmailCountResponse emailCount = null;

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
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
                                if (dc.ColumnName == "emailcount")
                                {
                                    value = Convert.ToInt32(dr[dc].ToString());
                                }
                            }
                            countDictionary.Add(key, value);
                        }
                    }

                    emailCount = new EmailCountResponse();
                    emailCount.inboxCount = countDictionary["InBox"];
                    emailCount.draftCount = countDictionary["Drafts"];
                    emailCount.sentItemCount = countDictionary["Sent Items"];
                    emailCount.trashCount = countDictionary["Trash"];
                    

                }

                return emailCount;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async static Task<bool> MarkReadEmail(string mailId)
        {
            try
            {

                MarkReadEmailApiParams param = new MarkReadEmailApiParams
                {
                    mailId = mailId,
                    read = true,
                    connectionName = WebserviceConstants.CONNECTION_NAME

                };

                FinalResponse response = await WebServiceHandler.GetWebserviceResult(WebserviceConstants.MARK_READ_EMAIL_URL,
                    HttpMethod.Post, param) as FinalResponse;

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return true;
                }else
                {
                    return false;
                }
                
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async static Task<List<EmailResponse>> InboxEmails(string userId, int mailTypeId)
        {
            try
            {
                InboxEmailApiParams param = new InboxEmailApiParams
                {
                    mailCount = 10,
                    mailTypeId = mailTypeId,
                    filterIndex = 0,
                    filterEmail = "",
                    blnShowblank = false,
                    intUserID = userId,
                    connectionName = WebserviceConstants.CONNECTION_NAME
                };
                var response = await WebServiceHandler.GetWebserviceResult(WebserviceConstants.SHOW_INBOX_EMAILS_URL,
                    HttpMethod.Post, param) as FinalResponse;

                List<EmailResponse> emailList = null;

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    DataSet resultIds = response.ResultDs;
                    foreach (DataTable dt in resultIds.Tables)
                    {
                        emailList = (from DataRow dr in dt.Rows
                                     select new EmailResponse()
                                     {
                                         MailId = dr["MailId"].ToString(),
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
                }

                return emailList;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public async static Task<string> EmailDetail(string mailId, string userId)
        {
            string emailDetail = null;
            try
            {

                EmailDetailsAPIParams param = new EmailDetailsAPIParams
                {
                    MailID = mailId,
                    uid = userId,
                    connectionName = WebserviceConstants.CONNECTION_NAME

                };

                var response = await WebServiceHandler.GetWebserviceResult(WebserviceConstants.EMAIL_DETAILS_URL,
                    HttpMethod.Post, param) as FinalResponse;

                var responseLst = response.ResultDoc as XmlNode[];
                emailDetail = responseLst.FirstOrDefault(x => x.Name == "retValue").InnerText;


                return emailDetail;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        /// <summary>
        /// Returns list of ShowNotes
        /// </summary>
        /// <param name="entityCode"></param>
        /// <param name="accountCode"></param>
        /// <param name="blnShowblank"></param>
        /// <returns></returns>
        public async static Task<List<CrmNotesResponse>> ShowNotes(string entityCode,
            string accountCode,
            bool blnShowblank)
        {
            try
            {
                CrmNotesAPIParams param = new CrmNotesAPIParams
                {
                    entityCode = entityCode,
                    accountCode = accountCode,                
                    blnShowblank = false,                
                    connectionName = WebserviceConstants.CONNECTION_NAME
                };
                var response = await WebServiceHandler.GetWebserviceResult(
                    WebserviceConstants.SHOW_NOTES_LIST_URL, HttpMethod.Post, param) 
                    as FinalResponse;

                List<CrmNotesResponse> notesList = null;

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    DataSet resultIds = response.ResultDs;
                    foreach (DataTable dt in resultIds.Tables)
                    {
                        notesList = (from DataRow dr in dt.Rows
                                     select new CrmNotesResponse()
                                     {
                                         NotesId = dr["NotesId"].ToString(),
                                         CreatedDate = Convert.ToDateTime(dr["CreatedDate"].ToString()),
                                         NotesHeader = dr["NotesHeader"].ToString(),
                                         NotesSubject = dr["NotesSubject"].ToString(),
                                         NotesDetail = dr["NotesDetail"].ToString(),
                                         CreatedBy = dr["CreatedBy"].ToString(),
                                         UserName = dr["UserName"].ToString(),
                                         ImageType = dr["ImageType"].ToString(),
                                         ActionTypeId = dr["ActionTypeId"].ToString(),
                                         SendTo = dr["SendTo"].ToString(),
                                         PrivacyId = dr["PrivacyId"].ToString(),
                                         CreatedBy1 = dr["CreatedBy1"].ToString()
                                         
                                     }).ToList();
                    }
                }

                return notesList;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// Returns list of Entity codes
        /// </summary>
        /// <returns></returns>
        public async static Task<List<EntityCodesResponse>> GetEntityCode()
        {
            try
            {
                EntityCodeAPIParams param = new EntityCodeAPIParams
                {                
                    connectionName = WebserviceConstants.CONNECTION_NAME
                };
                var response = await WebServiceHandler.GetWebserviceResult(
                    WebserviceConstants.GET_ENTITY_CODES_URL, HttpMethod.Post, param)
                    as FinalResponse;

                List<EntityCodesResponse> entityCodesList = null;

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    DataSet resultIds = response.ResultDs;
                    foreach (DataTable dt in resultIds.Tables)
                    {
                        entityCodesList = (from DataRow dr in dt.Rows
                                     select new EntityCodesResponse()
                                     {
                                         CompCode = dr["CompCode"].ToString(),                                  
                                         AccountCode = dr["AccountCode"].ToString(),                                        

                                     }).ToList();
                    }
                }

                return entityCodesList;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        /// <summary>
        /// Returns list of Account codes
        /// </summary>
        /// <param name="entityCode"></param>
        /// <returns></returns>
        public async static Task<List<AccountCodesResponse>> GetAccountCodes(string compCode)
        {
            try
            {
                AccountCodeAPIParams param = new AccountCodeAPIParams
                {
                    compCode = compCode,
                    connectionName = WebserviceConstants.CONNECTION_NAME
                };
                var response = await WebServiceHandler.GetWebserviceResult(
                    WebserviceConstants.GET_ACCOUNT_CODES_URL, HttpMethod.Post, param)
                    as FinalResponse;

                List<AccountCodesResponse> accountCodesList = null;

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    DataSet resultIds = response.ResultDs;
                    foreach (DataTable dt in resultIds.Tables)
                    {
                        accountCodesList = (from DataRow dr in dt.Rows
                                           select new AccountCodesResponse()
                                           {                                            
                                               AccountCode = dr["AccountCode"].ToString(),

                                           }).ToList();
                    }
                }

                return accountCodesList;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        /// <summary>
        /// Save Add notes
        /// </summary>
        /// <param name="addNotesApiParams"></param>
        /// <returns></returns>
        public async static Task<bool> AddCrmNotes(AddNotesAPIParams addNotesApiParams)
        {
            try
            {          
                FinalResponse response = await WebServiceHandler.GetWebserviceResult(
                    WebserviceConstants.ADD_NOTES_URL,
                    HttpMethod.Post, addNotesApiParams) as FinalResponse;

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                return false;
            }
        }


    }
}
