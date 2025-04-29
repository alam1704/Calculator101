using Calculator.Core.Factories;
using Calculator.Core.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Calculator.Service.Controllers
{
    public class CalculatorController : ApiController
    {
        [HttpPost]
        [Route("api/calculate")]
        public async Task<IHttpActionResult> Calculate(HttpRequestMessage request)
        {
            var content = await request.Content.ReadAsStringAsync();
            if (string.IsNullOrEmpty(content) || request == null)
            {
                return BadRequest("Invalid input.");
            }
            var calculationResult = new CalculationResult();
            try
            {
                CalculationResponse response = null;
                if (request.Content.Headers.ContentType.MediaType == "application/json")
                {
                    if (content.Contains("\"Maths\""))
                    {
                        var root = JsonConvert.DeserializeObject<RootObject>(content);
                        response = root.Response;
                    }
                    else
                    {
                        response = JsonConvert.DeserializeObject<CalculationResponse>(content);
                    }
                }
                else if (request.Content.Headers.ContentType.MediaType == "application/xml")
                {
                    var serializer = new System.Xml.Serialization.XmlSerializer(typeof(CalculationResponse));
                    using (var reader = new System.IO.StringReader(content))
                    {
                        response = (CalculationResponse)serializer.Deserialize(reader);
                    }
                }
                else
                {
                    return BadRequest("Unsupported content type.");
                }

                if (response == null || response.Operation == null)
                {
                    return BadRequest("No response received from API.");
                }
                var operation = OperationFactory.Create(response.Operation);
                var result = operation.Execute();


                calculationResult.Result = result;
                

                return Ok(calculationResult);
            }
            catch (Exception ex)
            {

                calculationResult.Error = ex.Message;

                return BadRequest(calculationResult.Error);
            }

        }

        //public HttpResponseMessage Calculate([FromBody] CalculationResponse response)
        //{
        //    var test = JsonConvert.SerializeObject(response);
        //    if (response == null || response.Operation == null)
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Invalid input.");
        //    }

        //    try
        //    {
        //        var operation = OperationFactory.Create(response.Operation);
        //        var result = operation.Execute();

        //        var calculationResult = new CalculationResult
        //        {
        //            Result = result,
        //        };

        //        return Request.CreateResponse(HttpStatusCode.OK, calculationResult);
        //    }
        //    catch (Exception ex)
        //    {
        //        var calculationResult = new CalculationResult
        //        {
        //            Error = ex.Message,
        //        };
        //        return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, calculationResult.Error);
        //    }

        //}

    }
}