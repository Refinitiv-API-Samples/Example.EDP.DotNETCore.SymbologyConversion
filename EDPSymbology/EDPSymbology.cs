﻿//----------------------
// <auto-generated>
//     Generated using the NSwag toolchain v12.0.14.0 (NJsonSchema v9.13.18.0 (Newtonsoft.Json v11.0.0.0)) (http://NSwag.org)
// </auto-generated>
//----------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Refinitiv.EDP.Example.Symbology.Convert
{
    
    #pragma warning disable
    using System.ComponentModel;

    [System.CodeDom.Compiler.GeneratedCode("NSwag", "12.0.14.0 (NJsonSchema v9.13.18.0 (Newtonsoft.Json v11.0.0.0))")]
    public partial class EDPSymbologyClient : IEDPSymbologyClient
    {
        private string _baseUrl = "https://api.refinitiv.com/data/symbology/beta1";
        private System.Net.Http.HttpClient _httpClient;
        private System.Lazy<Newtonsoft.Json.JsonSerializerSettings> _settings;
    
        public EDPSymbologyClient(System.Net.Http.HttpClient httpClient)
        {
            _httpClient = httpClient; 
            _settings = new System.Lazy<Newtonsoft.Json.JsonSerializerSettings>(() => 
            {
                var settings = new Newtonsoft.Json.JsonSerializerSettings();
                UpdateJsonSerializerSettings(settings);
                return settings;
            });
        }
    
        public string BaseUrl 
        {
            get { return _baseUrl; }
            set { _baseUrl = value; }
        }
    
        protected Newtonsoft.Json.JsonSerializerSettings JsonSerializerSettings { get { return _settings.Value; } }
    
        partial void UpdateJsonSerializerSettings(Newtonsoft.Json.JsonSerializerSettings settings);
        partial void PrepareRequest(System.Net.Http.HttpClient client, System.Net.Http.HttpRequestMessage request, string url);
        partial void PrepareRequest(System.Net.Http.HttpClient client, System.Net.Http.HttpRequestMessage request, System.Text.StringBuilder urlBuilder);
        partial void ProcessResponse(System.Net.Http.HttpClient client, System.Net.Http.HttpResponseMessage response);
    
        /// <param name="format">Format to be used</param>
        /// <returns>Result</returns>
        /// <exception cref="EDPSymbologyException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<Symbology> GetConvertAsync(string universe, System.Collections.Generic.IEnumerable<FieldEnum> to, Format? format)
        {
            return GetConvertAsync(universe, to, format,System.Threading.CancellationToken.None);
        }
    
        /// <param name="format">Format to be used</param>
        /// <returns>Result</returns>
        /// <exception cref="EDPSymbologyException">A server side error occurred.</exception>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        public async System.Threading.Tasks.Task<Symbology> GetConvertAsync(string universe, System.Collections.Generic.IEnumerable<FieldEnum> to, Format? format, System.Threading.CancellationToken cancellationToken)
        {
            if (universe == null)
                throw new System.ArgumentNullException("universe");

    
            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/convert?");
            urlBuilder_.Append("universe=").Append(System.Uri.EscapeDataString(ConvertToString(universe, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            
            if (to != null && to.Count()>0) 
            {
                urlBuilder_.Append("to=");
                foreach (var item_ in to)
                {
                    urlBuilder_.Append(System.Uri.EscapeDataString(ConvertToString(item_, System.Globalization.CultureInfo.InvariantCulture)));
                    if (item_ != to.Last())
                        urlBuilder_.Append(",");
                    else
                        urlBuilder_.Append("&");
                }
                
            }
            if (format != null) 
            {
                urlBuilder_.Append("format=").Append(System.Uri.EscapeDataString(ConvertToString(format, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            }
            urlBuilder_.Length--;
    
            var client_ = _httpClient;
            try
            {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    request_.Method = new System.Net.Http.HttpMethod("GET");
                    request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));
    
                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);
    
                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        if (response_.Content != null && response_.Content.Headers != null)
                        {
                            foreach (var item_ in response_.Content.Headers)
                                headers_[item_.Key] = item_.Value;
                        }
    
                        ProcessResponse(client_, response_);
    
                        var status_ = ((int)response_.StatusCode).ToString();
                        if (status_ == "200") 
                        {
                            var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false); 
                            var result_ = default(Symbology); 
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<Symbology>(responseData_, _settings.Value);
                                return result_; 
                            } 
                            catch (System.Exception exception_) 
                            {
                                throw new EDPSymbologyException("Could not deserialize the response body.", (int)response_.StatusCode, responseData_, headers_, exception_);
                            }
                        }
                        else
                        {
                            var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false); 
                            var result_ = default(Error); 
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<Error>(responseData_, _settings.Value);
                            } 
                            catch (System.Exception exception_) 
                            {
                                throw new EDPSymbologyException("Could not deserialize the response body.", (int)response_.StatusCode, responseData_, headers_, exception_);
                            }
                            throw new EDPSymbologyException<Error>("Error", (int)response_.StatusCode, responseData_, headers_, result_, null);
                        }
                    }
                    finally
                    {
                        if (response_ != null)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
            }
        }
    
        /// <param name="format">Format to be used</param>
        /// <returns>Result</returns>
        /// <exception cref="EDPSymbologyException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<Symbology> PostConvertAsync(ConvertRequest convertRequest, Format? format)
        {
            return PostConvertAsync(convertRequest, format, System.Threading.CancellationToken.None);
        }
    
        /// <param name="format">Format to be used</param>
        /// <returns>Result</returns>
        /// <exception cref="EDPSymbologyException">A server side error occurred.</exception>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        public async System.Threading.Tasks.Task<Symbology> PostConvertAsync(ConvertRequest convertRequest, Format? format, System.Threading.CancellationToken cancellationToken)
        {
            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/convert?");
            if (format != null) 
            {
                urlBuilder_.Append("format=").Append(System.Uri.EscapeDataString(ConvertToString(format, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            }
            urlBuilder_.Length--;
    
            var client_ = _httpClient;
            try
            {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    var content_ = new System.Net.Http.StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(convertRequest, _settings.Value));
                    Console.WriteLine(content_.ReadAsStringAsync().Result);
                    content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                    request_.Content = content_;
                    request_.Method = new System.Net.Http.HttpMethod("POST");
                    request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));
                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);
    
                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        if (response_.Content != null && response_.Content.Headers != null)
                        {
                            foreach (var item_ in response_.Content.Headers)
                                headers_[item_.Key] = item_.Value;
                        }
    
                        ProcessResponse(client_, response_);
    
                        var status_ = ((int)response_.StatusCode).ToString();
                        if (status_ == "200") 
                        {
                            var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false); 
                            var result_ = default(Symbology); 
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<Symbology>(responseData_, _settings.Value);
                                return result_; 
                            } 
                            catch (System.Exception exception_) 
                            {
                                throw new EDPSymbologyException("Could not deserialize the response body.", (int)response_.StatusCode, responseData_, headers_, exception_);
                            }
                        }
                        else
                        {
                            var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false); 
                            var result_ = default(Error); 
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<Error>(responseData_, _settings.Value);
                            } 
                            catch (System.Exception exception_) 
                            {
                                throw new EDPSymbologyException("Could not deserialize the response body.", (int)response_.StatusCode, responseData_, headers_, exception_);
                            }
                            throw new EDPSymbologyException<Error>("Error", (int)response_.StatusCode, responseData_, headers_, result_, null);
                        }
                    }
                    finally
                    {
                        if (response_ != null)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
            }
        }
    
        /// <returns>Generic OPTIONS response</returns>
        /// <exception cref="EDPSymbologyException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task Convert3Async()
        {
            return Convert3Async(System.Threading.CancellationToken.None);
        }
    
        /// <returns>Generic OPTIONS response</returns>
        /// <exception cref="EDPSymbologyException">A server side error occurred.</exception>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        public async System.Threading.Tasks.Task Convert3Async(System.Threading.CancellationToken cancellationToken)
        {
            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/convert");

            var client_ = _httpClient;
            try
            {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    request_.Content = new System.Net.Http.StringContent(string.Empty, System.Text.Encoding.UTF8, "application/json");
                    request_.Method = new System.Net.Http.HttpMethod("OPTIONS");

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        if (response_.Content != null && response_.Content.Headers != null)
                        {
                            foreach (var item_ in response_.Content.Headers)
                                headers_[item_.Key] = item_.Value;
                        }

                        ProcessResponse(client_, response_);

                        var status_ = ((int)response_.StatusCode).ToString();
                        if (status_ == "200")
                        {
                            return;
                        }
                        else
                        if (status_ != "200" && status_ != "204")
                        {
                            var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new EDPSymbologyException("The HTTP status code of the response was not expected (" + (int)response_.StatusCode + ").", (int)response_.StatusCode, responseData_, headers_, null);
                        }
                    }
                    finally
                    {
                        if (response_ != null)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
            }
        }
    
        private string ConvertToString(object value, System.Globalization.CultureInfo cultureInfo)
        {
            if (value is System.Enum)
            {
                string name = System.Enum.GetName(value.GetType(), value);
                if (name != null)
                {
                    var field = System.Reflection.IntrospectionExtensions.GetTypeInfo(value.GetType()).GetDeclaredField(name);
                    if (field != null)
                    {
                        var attribute = System.Reflection.CustomAttributeExtensions.GetCustomAttribute(field, typeof(System.Runtime.Serialization.EnumMemberAttribute)) 
                            as System.Runtime.Serialization.EnumMemberAttribute;
                        if (attribute != null)
                        {
                            return attribute.Value;
                        }
                    }
                }
            }
            else if (value is bool) {
                return System.Convert.ToString(value, cultureInfo).ToLowerInvariant();
            }
            else if (value is byte[])
            {
                return System.Convert.ToBase64String((byte[]) value);
            }
            else if (value != null && value.GetType().IsArray)
            {
                var array = System.Linq.Enumerable.OfType<object>((System.Array) value);
                return string.Join(",", System.Linq.Enumerable.Select(array, o => ConvertToString(o, cultureInfo)));
            }
        
            return System.Convert.ToString(value, cultureInfo);
        }

        public static System.Collections.Generic.List<FieldEnum> ConvertStringToEnumList(List<string> inputList,out string errorMsg)
        {
            var returnList = new System.Collections.Generic.List<FieldEnum>();
            var errorFieldStr = new System.Text.StringBuilder();
            errorMsg = string.Empty;
            foreach (var input in inputList)
            {
                if(Enum.IsDefined(typeof(FieldEnum), input))
                    returnList.Add(Enum.Parse<FieldEnum>(input));
                else
                {
                    errorFieldStr.Append("\"");
                    errorFieldStr.Append(input);
                    errorFieldStr.Append("\"");
                    if(input != inputList.Last())
                    errorFieldStr.Append(",");
                }
            }

            if (errorFieldStr.ToString() != string.Empty)
            {
                errorMsg=$"{errorFieldStr.ToString()} is not list in FieldEnum, the value will be removed from list";
            }

            return returnList;
        }
    }


    //// <summary> OperationError provides additional information about problems encountered while performing an operation,

#pragma warning restore
}