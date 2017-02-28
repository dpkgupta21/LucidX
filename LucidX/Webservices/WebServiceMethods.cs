using System;
using System.Threading.Tasks;
using System.Xml.Serialization;
using LucidX.RequestModels;
using LucidX.ResponseModels;
using LucidX.Constants;
using System.Net.Http;

namespace LucidX
{
	public class WebServiceMethods
	{
		public async static Task<FinalResponse> Login(ElucidateAPIParams param) {
			try
			{
				var response = await Webservices.WebServiceHandler.GetWebserviceResult(WebserviceConstants.LOGIN_URL,
                    HttpMethod.Post, param);
                //await Task.Delay(5000);
                return response as FinalResponse;
			}
			catch (Exception ex){
				return null;
			}
		}






	}
}
