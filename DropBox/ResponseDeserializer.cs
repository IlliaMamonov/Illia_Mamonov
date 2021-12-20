using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;

namespace DropBox
{
    public sealed partial class FolderContentReceiver
    {
        internal sealed partial class ResponseDeserializer
        {
            /// <summary>
            /// Deserializes the response content (check response-example.json)
            /// </summary>
            /// <param name="response"></param>
            /// <returns>A Json object representation</returns>
            public JObject GetDeserializedResponse(IRestResponse response)
            {
                return JsonConvert.DeserializeObject<JObject>(response.Content);
            }

            /// <summary>
            ///A cursor value has to be included to the next request
            ///if there are more elements to get from the folder
            /// </summary>
            /// <param name="deserializedResponse"></param>
            /// <returns>A string representation of a "cursor" field from a deserialized response</returns>
            public string GetCursor(JObject deserializedResponse)
            {
                return deserializedResponse["cursor"].ToString();
            }

            /// <summary>
            /// (check entries-example.json)
            /// </summary>
            /// <param name="deserializedResponse"></param>
            /// <returns>An array representation of "entries" field from the deserialized response</returns>
            public JArray GetEntries(JObject deserializedResponse)
            {
                JToken entries = deserializedResponse["entries"];
                return JsonConvert.DeserializeObject<JArray>(entries.ToString());
            }
            /// <summary>
            /// This method represents a "has_more" field in a response
            /// True if there are more elements in a folder
            /// which could not be received by the request
            /// </summary>
            /// <param name="deserializedResponse"></param>
            /// <returns>A Boolen representation of "has_more" field</returns>
            public bool HasMore(JObject deserializedResponse)
            {
                return (bool)deserializedResponse["has_more"];
            }


            /// <summary>
            /// This method finds the name of every file which is specified in the response
            /// </summary>
            /// <param name="entries"></param>
            /// <returns>An collection of file names from the current response</returns>
            public IEnumerable<string> GetFileNames(JArray entries)
            {
                var files = new List<string>();
                foreach (var entry in entries)
                {
                    var deserializedEntry = JsonConvert.DeserializeObject<JObject>(entry.ToString());
                    (var isFile, var fileName) = TryGetFileName(deserializedEntry);
                    if (isFile)
                    {
                        files.Add(fileName);
                    }
                }

                return files;
            }

            public (bool isFile, string fileName) TryGetFileName(JObject deserializedEntry)
            {
                if (deserializedEntry[".tag"].ToString() == "file")
                {
                    return (true, deserializedEntry["name"].ToString());
                }
                return (false, String.Empty);
            }
        }
    }
}