using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace M9_Discord_Bot.HumorAPI.Model
{

  /// <summary>
  /// 
  /// </summary>
  [DataContract]
  public class InlineResponse2002 {
    /// <summary>
    /// Gets or Sets Memes
    /// </summary>
    [DataMember(Name="memes", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "memes")]
    public List<Object> Memes { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class InlineResponse2002 {\n");
      sb.Append("  Memes: ").Append(Memes).Append("\n");
      sb.Append("}\n");
      return sb.ToString();
    }

    /// <summary>
    /// Get the JSON string presentation of the object
    /// </summary>
    /// <returns>JSON string presentation of the object</returns>
    public string ToJson() {
      return Newtonsoft.Json.JsonConvert.SerializeObject(this, Newtonsoft.Json.Formatting.Indented);
    }

}
}