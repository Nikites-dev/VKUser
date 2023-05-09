using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using VKUser;
using Xunit;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using TestUser.Models;
using User = VKUser.Models.User;

namespace TestUser
{
    public class UnitTest1
    {
        [Fact]
        public async void GetUserById()
        {
            var user = (await NetManager.Get<User>("users/get/1"));
        
            Assert.Equal(user.Login, "test");
        }

        [Fact]
        public async void GetNonExistentUserById()
        {
            var user = (await NetManager.Get<User>("users/get/888"));
            Assert.Null(user.Login);
        }

        [Fact]
        public async void CreateNewUser()
        {
            User user = new User();
            user.Login = "petrovn2@gmail.com";
            user.Password = "goodday";
            user.UserGroupId = 2;

            var jsonData = JsonConvert.SerializeObject(user);
            var response = await NetManager.Post($"users/post?login={user.Login}&password={user.Password}&userGroupId={user.UserGroupId}", new StringContent(jsonData, Encoding.UTF8, "application/json"));
           
            Assert.Equal(response.StatusCode, HttpStatusCode.OK );
        }

        [Fact]
        public async void CreateNewUserWithEmptyData()
        {
            User user = new User();

            var jsonData = JsonConvert.SerializeObject(user);
            var response = await NetManager.Post($"users/post?login={user.Login}&password={user.Password}&userGroupId={user.UserGroupId}", new StringContent(jsonData, Encoding.UTF8, "application/json"));
           
            Assert.Equal(response.StatusCode, HttpStatusCode.BadRequest );
        }

        [Fact]
        public async void CreateNewSecondAdminUser()
        {
            User user = new User();
            user.Login = "admin2@test.com";
            user.Password = "goodday";
            user.UserGroupId = 1;

            var jsonData = JsonConvert.SerializeObject(user);
            var response = await NetManager.Post($"users/post?login={user.Login}&password={user.Password}&userGroupId={user.UserGroupId}", new StringContent(jsonData, Encoding.UTF8, "application/json"));
           
            Assert.Equal(response.StatusCode, HttpStatusCode.BadRequest );
        }

        [Fact]
        async void DeleteExistUser()
        {
            var response = await NetManager.Delete<User>("users/delete/21");
            Assert.Equal(response.StatusCode, HttpStatusCode.OK); 
        }

        [Fact]
        async void DeleteNotExistUser()
        {
            var response = await NetManager.Delete<User>("users/delete/888");
            Assert.Equal(response.StatusCode, HttpStatusCode.BadRequest); 
        }

        [Fact]
        void GetAllUsers()
        {
            var response =  NetManager.GetAll<User>("users/getAll");
            Assert.NotNull(response);
        }

        [Fact]
        public async void Test()
        {
            WebClientManager wb = new WebClientManager();
            wb.Start();
        }
    } 
}

