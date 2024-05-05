using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
    
    public class IEstoqueConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(IEstoque).IsAssignableFrom(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject jsonObject = JObject.Load(reader);

            if (jsonObject["Frete"] != null)
            {
                return jsonObject.ToObject<ProdutoFisico>();
            }
            else if (jsonObject["Autor"] != null)
            {
                return jsonObject.ToObject<ProdutoEbook>();
            }
            else 
            {
                return jsonObject.ToObject<ProdutoCurso>();
            }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }