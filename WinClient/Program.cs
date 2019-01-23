using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace WinClient
{

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
		/// 
		//asf
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
           // AddRegisterUser();
          //  int i = GetRegisterUserCount(); 
            AddEmployee();
            int j = GetEmployeeCount();

        }

		private static void AddEmployee()
		{
			try
			{
                  
				EmployeeModel appUser = new EmployeeModel
				{
					FirstName = "prra kumar",
					LastName = "poli",
					Address = "909 main Road"
				};

				using (var client = new HttpClient())
				{
					client.DefaultRequestHeaders.Accept.Clear();
					client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
					client.BaseAddress = new Uri("http://localhost:57303/");

					var serializedProduct = JsonConvert.SerializeObject(appUser);
					var content = new StringContent(serializedProduct, Encoding.UTF8, "application/json");
					var result = client.PostAsync("http://localhost:57303/api/Employee", content).Result;
				}
			}
			catch (Exception Ex)
			{
				var aa = Ex.Message;
			}
		}

		private static int GetRegisterUserCount()
        {
            int retVal=0;
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.BaseAddress = new Uri("http://localhost:57303/");
                //GET Method  
                HttpResponseMessage response = client.GetAsync("http://localhost:57303/api/RegisterUser").Result;
                if (response.IsSuccessStatusCode)
                {
                    string str = response.Content.ReadAsStringAsync().Result;
                    List<RegisterUserModel> users = JsonConvert.DeserializeObject<List<RegisterUserModel>>(str);
                    retVal = users.Count;

                    //foreach (RegisterUserModel item in users)
                    //{
                    //    MessageBox.Show(item.AppID);
                    //}
                }
                else
                {
                    Console.WriteLine("Internal server Error");
                }
            }
            return retVal;
        }

		private static int GetEmployeeCount()
		{
			int retVal = 0;
			using (var client = new HttpClient())
			{
				client.DefaultRequestHeaders.Accept.Clear();
				client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				client.BaseAddress = new Uri("http://localhost:57303/");
				//GET Method  
				HttpResponseMessage response = client.GetAsync("http://localhost:57303/api/Employee").Result;
				if (response.IsSuccessStatusCode)
				{
					string str = response.Content.ReadAsStringAsync().Result;
					List<EmployeeModel> users = JsonConvert.DeserializeObject<List<EmployeeModel>>(str);
					retVal = users.Count;
				}
				else
				{
					Console.WriteLine("Internal server Error");
				}
			}
			return retVal;
		}

		private static void AddRegisterUser()
        {
            try
            {

                RegisterUserModel appUser = new RegisterUserModel()
                //appUser.AppID = "TestAppRegisterUser";

                { AppID = "TestAppRegisterUser", Mobile = "9999999", DeviceID = "455",Email="test@test.com",
                  FirstName="Test",LastName="User", Remark = "From WinApp",DateCreate=DateTime.Now,DateUpdate=DateTime.Now };

                HttpClient client = new HttpClient();
                //using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.BaseAddress = new Uri("http://localhost:57303/");


                    //client.DefaultRequestHeaders.Accept.Clear();
                    //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    //client.BaseAddress = new Uri("http://localhost:57303/");

                    var serializedProduct = JsonConvert.SerializeObject(appUser);
                    var content = new StringContent(serializedProduct, Encoding.UTF8, "application/json");
                    var result = client.PostAsync("http://localhost:57303/api/RegisterUser", content).Result;
                }
            }
            catch (Exception Ex)
            {
                var aa = Ex.Message;
            }
        }
    }
}
