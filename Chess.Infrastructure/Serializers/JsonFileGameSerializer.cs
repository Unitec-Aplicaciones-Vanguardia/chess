using System;
using System.Collections.Generic;
using System.Text;
using Chess.Core.Interfaces;
using Chess.Core.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Chess.Infrastructure.Serializers
{
    public class JsonFileGameSerializer : IMovementSerializer
    {
        public Movement SerializeMovement(string data)
        {
            if (string.IsNullOrEmpty(data))
            {
                throw new ArgumentNullException();
            }

            return JsonConvert.DeserializeObject<Movement>(data);
        }
    }
}
