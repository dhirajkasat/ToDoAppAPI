using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;
using Newtonsoft.Json.Linq;
using System.Collections;

namespace ToDoApp.Controllers
{
    public class HomeController : ApiController
    {
        List<string> Tasks = new List<string>(new string[] { "Coding", "Bug Fixing", "Analysis","Deployment","Demo","RCA" });


        [Route("todo/api/v1.0/tasks")]
        [HttpGet]
        public RawJsonActionResult RetrieveList()
        {
            dynamic jresponse = new JObject();
            var request = HttpContext.Current.Request;
            string token = request.Headers["Token"];
            if (token == "135a1eb922ae3aa21eefa5be17f510ec")
            {
                try
                {
                    int count = 0;
                    ArrayList arlist = new ArrayList();
                    dynamic Jarray = new JArray();
                    foreach (string item in Tasks)
                    {
                        count++;
                        dynamic jobjects = new JObject();
                        //jobjects = "{\"id\":" + count + ","+"\r\n"+"\"task\":"  +"\u0022"  +item.ToString() + "\u0022"  +"}";
                        jobjects.id = count;
                        jobjects.task = item.ToString();
                        arlist.Add(jobjects);
                    }
                    JArray jsArray = new JArray(arlist);
                    jresponse.result = jsArray;
                }
                catch (Exception ex)
                {
                    jresponse = "{\"status\":" + false + ",\"message\":\"Some error Occured\"}";
                    return new RawJsonActionResult(jresponse.ToString());
                }
            }
            else
            {
                jresponse = "{\"status\":" + false + ",\"message\":\"Invalid Token\"}";
                return new RawJsonActionResult(jresponse.ToString());
            }

            return new RawJsonActionResult(jresponse.ToString());
        }

        [Route("todo/api/v1.0/tasks/id")]
        [HttpGet]
        public RawJsonActionResult RetrieveTask(string id)
        {
            dynamic jresponse = new JObject();
            var request = HttpContext.Current.Request;
            string token = request.Headers["Token"];
            if (token == "135a1eb922ae3aa21eefa5be17f510ec")
            {
                try
                {
                    var isNum = int.TryParse(id, out int num);
                    if (isNum)
                    {
                        if (num <= Tasks.Count)
                        {
                            jresponse.status = true;
                            jresponse.id = Convert.ToInt32(id);
                            jresponse.task = Tasks.ElementAt(Convert.ToInt32(id));
                        }
                        else
                        {
                            jresponse = "{\"status\":" + false + ",\"message\":\"Invalid ID\"}";
                            return new RawJsonActionResult(jresponse.ToString());
                        }
                    }
                    else
                    {
                        jresponse = "{\"status\":" + false + ",\"message\":\"Invalid ID\"}";
                        return new RawJsonActionResult(jresponse.ToString());
                    }
                }
                catch (Exception ex)
                {
                    jresponse = "{\"status\":" + false + ",\"message\":\"Some error Occured\"}";
                    return new RawJsonActionResult(jresponse.ToString());
                }
            }
            else
            {
                jresponse = "{\"status\":" + false + ",\"message\":\"Invalid Token\"}";
                return new RawJsonActionResult(jresponse.ToString());
            }

            return new RawJsonActionResult(jresponse.ToString());
        }

        [Route("todo/api/v1.0/create")]
        [HttpPost]
        public RawJsonActionResult CreateTask(string task)
        {
            dynamic jresponse = new JObject();
            var request = HttpContext.Current.Request;
            string token = request.Headers["Token"];
            if(token == "135a1eb922ae3aa21eefa5be17f510ec") 
            {
                try
                {
                    if (!string.IsNullOrEmpty(task))
                    {
                        Tasks.Add(task.ToString());
                        jresponse = "{\"status\":" + true + ",\"message\":\"Task Created Successfully\"}";
                    }
                    else
                    {
                        jresponse = "{\"status\":" + false + ",\"message\":\"Bad Request\"}";
                        return new RawJsonActionResult(jresponse.ToString());
                    }
                }
                catch (Exception ex)
                {
                    jresponse = "{\"status\":" + false + ",\"message\":\"Some error Occured\"}";
                    return new RawJsonActionResult(jresponse.ToString());
                }
            }
            else
            {
                jresponse = "{\"status\":" + false + ",\"message\":\"Invalid Token\"}";
                return new RawJsonActionResult(jresponse.ToString());
            }
            
            return new RawJsonActionResult(jresponse.ToString());
        }

        [Route("todo/api/v1.0/update")]
        [HttpPut]
        public RawJsonActionResult UpdateTask(string id,string task)
        {
            dynamic jresponse = new JObject();
            var request = HttpContext.Current.Request;
            string token = request.Headers["Token"];
            if (token == "135a1eb922ae3aa21eefa5be17f510ec")
            {
                try
                {
                    if (!string.IsNullOrEmpty(task) && !string.IsNullOrEmpty(id))
                    {
                        Tasks[Convert.ToInt32(id)] = task;
                        jresponse = "{\"status\":" + true + ",\"message\":\"Updated Successfully\"}";
                    }
                    else
                    {
                        jresponse = "{\"status\":" + false + ",\"message\":\"Bad Request\"}";
                        return new RawJsonActionResult(jresponse.ToString());
                    }
                }
                catch (Exception ex)
                {
                    jresponse = "{\"status\":" + false + ",\"message\":\"Some error Occured\"}";
                    return new RawJsonActionResult(jresponse.ToString());
                }
            }
            else
            {
                jresponse = "{\"status\":" + false + ",\"message\":\"Invalid Token\"}";
                return new RawJsonActionResult(jresponse.ToString());
            }

            return new RawJsonActionResult(jresponse.ToString());
        }

        [Route("todo/api/v1.0/delete")]
        [HttpDelete]
        public RawJsonActionResult DeleteTask(string id)
        {
            dynamic jresponse = new JObject();
            var request = HttpContext.Current.Request;
            string token = request.Headers["Token"];
            if (token == "135a1eb922ae3aa21eefa5be17f510ec")
            {
                try
                {
                    if (!string.IsNullOrEmpty(id))
                    {
                        if(int.TryParse(id,out _))
                        {
                            Tasks.RemoveAt(Convert.ToInt32(id));
                            jresponse = "{\"status\":" + true + ",\"message\":\"Deleted Successfully\"}";
                        }
                        else
                        {
                            jresponse = "{\"status\":" + false + ",\"message\":\"Bad Request\"}";
                            return new RawJsonActionResult(jresponse.ToString());
                        }

                    }
                    else
                    {
                        jresponse = "{\"status\":" + false + ",\"message\":\"Bad Request\"}";
                        return new RawJsonActionResult(jresponse.ToString());
                    }
                }
                catch (Exception ex)
                {
                    jresponse = "{\"status\":" + false + ",\"message\":\"Some error Occured\"}";
                    return new RawJsonActionResult(jresponse.ToString());
                }
              
            }
            else
            {
                jresponse = "{\"status\":" + false + ",\"message\":\"Invalid Token\"}";
                return new RawJsonActionResult(jresponse.ToString());
            }

            return new RawJsonActionResult(jresponse.ToString());
        }

        public class RawJsonActionResult : IHttpActionResult
        {
            private readonly string _jsonString;

            public RawJsonActionResult(string jsonString)
            {
                _jsonString = jsonString;
            }

            public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
            {
                var content = new StringContent(_jsonString);
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var response = new HttpResponseMessage(HttpStatusCode.OK) { Content = content };
                return Task.FromResult(response);
            }
        }
    }
}
