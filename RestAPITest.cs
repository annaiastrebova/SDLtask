using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace APItest
{
    [TestClass]
    public class RestApiTest1
    {
        [TestMethod]
        public void CreateUser()
        {
            string jsonString = @"{
                                    ""name"": ""morpheus"",
                                    ""job"": ""leader""
                                  }";

            APIHelper<CreatedUsers> restAPI = new APIHelper<CreatedUsers>();
            var restUrl = restAPI.SetUrl("api/users");
            var restRequest = restAPI.CreatePostRequest(jsonString);
            var response = restAPI.GetResponse(restUrl, restRequest);
            CreatedUsers content = restAPI.GetContent<CreatedUsers>(response);

            Assert.AreEqual(content.name, "morpheus");
            Assert.AreEqual(content.job, "leader");

        }

        [TestMethod]
        public void UpdatePutUser()
        {
            string jsonString = @"{
                                    ""name"": ""morpheus"",
                                    ""job"": ""zion resident""
                                  }";

            APIHelper<UpdatedUsers> restAPI = new APIHelper<UpdatedUsers>();
            var restUrl = restAPI.SetUrl("api/users/2");
            var restRequest = restAPI.CreatePutRequest(jsonString);
            var response = restAPI.GetResponse(restUrl, restRequest);
            UpdatedUsers content = restAPI.GetContent<UpdatedUsers>(response);

            Assert.AreEqual(content.name, "morpheus");
            Assert.AreEqual(content.job, "zion resident");

        }

        [TestMethod]
        public void UpdatePatchUser()
        {
            string jsonString = @"{
                                    ""name"": ""morpheus"",
                                    ""job"": ""zion resident""
                                  }";

            APIHelper<UpdatedUsers> restAPI = new APIHelper<UpdatedUsers>();
            var restUrl = restAPI.SetUrl("api/users/2");
            var restRequest = restAPI.CreatePatchRequest(jsonString);
            var response = restAPI.GetResponse(restUrl, restRequest);
            UpdatedUsers content = restAPI.GetContent<UpdatedUsers>(response);

            Assert.AreEqual(content.name, "morpheus");
            Assert.AreEqual(content.job, "zion resident");

        }

        [TestMethod]
        public void DeleteUser()
        {
            APIHelper<UpdatedUsers> restAPI = new APIHelper<UpdatedUsers>();
            var restUrl = restAPI.SetUrl("api/users/2");
            var restRequest = restAPI.CreateDeleteRequest();
            var response = restAPI.GetResponse(restUrl, restRequest);
            UpdatedUsers content = restAPI.GetContent<UpdatedUsers>(response);

            Assert.AreEqual(content, null);
        }

        [TestMethod]
        public void ListUsers()
        {
            APIHelper<UsersCollection> restAPI = new APIHelper<UsersCollection>();
            var restUrl = restAPI.SetUrl("api/users?page=2");
            var restRequest = restAPI.CreateGetRequest();
            var response = restAPI.GetResponse(restUrl, restRequest);
            UsersCollection content = restAPI.GetContent<UsersCollection>(response);

            Assert.AreEqual(content.page, 2);
            Assert.AreEqual(content.per_page, 6);
            Assert.AreEqual(content.total, 12);
            Assert.AreEqual(content.total_pages, 2);
            Assert.AreEqual(content.data.Count, 6);
        }

    }
}
