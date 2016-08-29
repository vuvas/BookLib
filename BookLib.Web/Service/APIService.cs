using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Web.Mvc;
using BookLib.Web.Models;
using RestSharp;

namespace BookLib.Web.Service
{
    
    public class ApiService:IApiService
    {
        private readonly RestClient _client;
        
        private readonly string _url = ConfigurationManager.AppSettings["webApiUrl"];

        public ApiService()
        {
            _client = new RestClient(_url);
        }
        
        #region GET METHOD
        public IEnumerable<Book> GetAll()
        {
            var request = new RestRequest("api/books/getall", Method.GET) { RequestFormat = DataFormat.Json };
            try
            {
                var response = _client.Execute<List<Book>>(request);

                if (response.Data == null)
                    throw new Exception(response.ErrorMessage);

                return response.Data;
            }
            catch (Exception e)
            {
                //TODO: LOGGING
                throw e;
            }
           
        }

        public List<SelectListItem> GetFilterTypes()
        {
            var request = new RestRequest("api/books/FilterTypes", Method.GET) { RequestFormat = DataFormat.Json };
            try
            {
                var response = _client.Execute<List<SelectListItem>>(request);

                if (response.Data == null)
                    throw new Exception(response.ErrorMessage);

                return response.Data;
            }
            catch (Exception e)
            {
                //TODO: LOGGING
                throw e;
            }
        }

        public  IEnumerable<Book> SeachBooks(string keyword, string searchType = null)
        {
            var request = new RestRequest("api/books/search", Method.GET) { RequestFormat = DataFormat.Json };
            request.AddParameter("SearchType", searchType);
            request.AddParameter("keyword", keyword);
            try
            {
                var response = _client.Execute<List<Book>>(request);

                if (response.Data == null)
                    throw new Exception(response.ErrorMessage);
                return response.Data;
            }
            catch (Exception e)
            {
                //TODO: LOGGING
                throw e;
            }
           
            
        }

        public User GetUser(string id)
        {
            var request = new RestRequest("api/Account/GetUser", Method.GET) { RequestFormat = DataFormat.Json };
            request.AddParameter("Id",id);
            
            try
            {
                var response = _client.Execute<User>(request);

                if (response.Data == null)
                    throw new Exception(response.ErrorMessage);
                return response.Data;
            }
            catch (Exception e)
            {
                //TODO: LOGGING
                throw e;
            }
        }

        public User GetUserByUsername(string username)
        {
            var request = new RestRequest("api/Account/GetUserByUsername", Method.GET) { RequestFormat = DataFormat.Json };
            request.AddParameter("username", username);
            
            try
            {
                var response = _client.Execute<User>(request);

                if (response.Data == null)
                    throw new Exception(response.ErrorMessage);
                return response.Data;
            }
            catch (Exception e)
            {
                //TODO: LOGGING
                throw e;
            }
        }

        #endregion


        #region POST METHOD
        public Result PlaceDemand(string userID, string bookID)
        {
            var request = new RestRequest(string.Format(@"api/books/PlaceDemand?userID={0}&bookID={1}",userID,bookID), Method.POST);
            
            try
            {
                var response = _client.Execute<Result>(request);
                if (response.StatusCode != HttpStatusCode.OK)
                    throw new Exception(response.ErrorMessage); 
                
                return response.Data;
            }
            catch (Exception e)
            {
                //TODO: LOGGING
                throw e;
                
            }

        }

        public Result SaveUser(string username, string password)
        {
            var request = new RestRequest(string.Format("api/Account/SaveUser?username={0}&password={1}",username,password), Method.POST) { RequestFormat = DataFormat.Json };


            try
            {
                var response = _client.Execute<Result>(request);
                if (response.StatusCode != HttpStatusCode.OK)
                    throw new Exception(response.ErrorMessage);

                return response.Data;
            }
            catch (Exception e)
            {
                //TODO: LOGGING
                throw e;

            }
        }

        public Result AuthenticateUser(string username, string password)
        {
            var request = new RestRequest(string.Format("api/Account/AuthenticateUser?username={0}&password={1}", username, password), Method.POST) { RequestFormat = DataFormat.Json };


            try
            {
                var response = _client.Execute<Result>(request);
                if (response.StatusCode != HttpStatusCode.OK)
                    throw new Exception(response.ErrorMessage);

                return response.Data;
            }
            catch (Exception e)
            {
                //TODO: LOGGING
                throw e;

            }
        }

        public Result ChangePassword(string id, string newPassword)
        {
            var request = new RestRequest("api/Account/SaveUser", Method.POST) { RequestFormat = DataFormat.Json };
            request.AddBody(id);
            request.AddBody(newPassword);

            try
            {
                var response = _client.Execute<Result>(request);
                if (response.StatusCode != HttpStatusCode.Created)
                    throw new Exception(response.ErrorMessage);

                return response.Data;
            }
            catch (Exception e)
            {
                //TODO: LOGGING
                throw e;

            }
        }

        #endregion
    }
}