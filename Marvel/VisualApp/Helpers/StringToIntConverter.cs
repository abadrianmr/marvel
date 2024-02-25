using Newtonsoft.Json;
using System;

namespace VisualApp.Helpers
{
    /// <summary>
    /// Converts JSON strings to nullable integers and vice versa.
    /// </summary>
    public class StringToIntConverter : JsonConverter
    {
        /// <summary>
        /// Determines whether this converter can convert the specified type to/from JSON.
        /// </summary>
        /// <param name="objectType">The type to check for compatibility with this converter.</param>
        /// <returns>True if the converter can convert the specified type; otherwise, false.</returns>
        public override bool CanConvert( Type objectType )
        {
            return objectType == typeof( int? );
        }

        /// <summary>
        /// Reads JSON data and converts it to the specified type (int?).
        /// </summary>
        /// <param name="reader">The JsonReader containing the JSON data.</param>
        /// <param name="objectType">The type to convert the JSON data to.</param>
        /// <param name="existingValue">The existing value of the object being read.</param>
        /// <param name="serializer">The calling serializer.</param>
        /// <returns>The converted object.</returns>
        public override object? ReadJson( JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer )
        {
            if( reader.TokenType == JsonToken.Null )
                return null;
            if( reader.TokenType == JsonToken.Integer )
                return reader.Value;

            if( reader.TokenType == JsonToken.String )
            {
                if( string.IsNullOrEmpty( (string) reader.Value ) || ( (string) reader.Value ) == "null" )
                    return null;
                int num;
                if( int.TryParse( (string) reader.Value, out num ) )
                    return num;

                throw new JsonReaderException( string.Format( "Expected integer, got {0}", reader.Value ) );
            }
            throw new JsonReaderException( string.Format( "Unexcepted token {0}", reader.TokenType ) );
        }

        /// <summary>
        /// Writes the JSON representation of the object (int?) to the writer.
        /// </summary>
        /// <param name="writer">The JsonWriter to write to.</param>
        /// <param name="value">The value to write.</param>
        /// <param name="serializer">The calling serializer.</param>
        public override void WriteJson( JsonWriter writer, object value, JsonSerializer serializer )
        {
            writer.WriteValue( value );
        }
    }
}
