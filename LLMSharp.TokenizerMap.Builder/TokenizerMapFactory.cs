
﻿

using Google.Protobuf;
using System.Diagnostics.Contracts;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Nodes;
using static Google.Protobuf.Reflection.SourceCodeInfo.Types;

namespace LLMSharp.TokenizerMap.Builder
{
    /// <summary>
    /// Tokenizer Map Factory class constructs tokenizer maps for various LLMs
    /// </summary>
    internal class TokenizerMapFactory
    {
        /// <summary>
        /// Construct TokenizerMaps by parsing a remote json file. Will return null if the url is invalid or json in the file is invalid.
        /// Expects a JsonFile with 'bpe_ranks' , 'pat_str' properties and an optional 'special_tokens' property.
        /// </summary>
        /// <param name="remoteJsonFileUrl">Url for the remote json file</param>
        /// <param name="cancellationToken">Cancellation Token</param>
        /// <returns>Constructed tokenizer maps. null if the json file is not valid</returns>
        internal async Task<TokenizerMaps?> ConstructFromRemoteJsonFileAsync(Uri remoteJsonFileUrl, CancellationToken cancellationToken)
        {
            using var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");

            try
            {
                var jObj = await httpClient.GetFromJsonAsync<TokenizerRegistry>(remoteJsonFileUrl, cancellationToken);
                if (jObj == null)
                {
                    Console.Error.WriteLine($"Invalid Json found @{remoteJsonFileUrl}. Terminating tokenizer maps construction");
                    return null;
                }

                return ConstructFromRegistry(jObj, cancellationToken);
            }
            catch(OperationCanceledException) 
            {
                Console.WriteLine("Operation cancelled. Terminating TokenizerMaps construction");
                return null;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Unknown error: {ex}");
                return null;
            }
        }

        /// <summary>
        /// Construct TokenizerMaps by parsing a JsonFile. Will return null if the JsonFile has invalid json.
        /// Expects a JsonFile with 'bpe_ranks' , 'pat_str' properties and an optional 'special_tokens' property.
        /// </summary>
        /// <param name="jsonFilePath">JsonFile location for constructing tokenizer maps</param>
        /// <param name="cancellationToken">Cancellation Token</param>
        /// <returns>Constructed tokenizer maps. null if the json file is not valid</returns>
        internal async Task<TokenizerMaps?> ConstructFromJsonFileAsync(string jsonFilePath, CancellationToken cancellationToken)
        {
            string json = await File.ReadAllTextAsync(jsonFilePath, System.Text.Encoding.UTF8, cancellationToken).ConfigureAwait(false);
            TokenizerRegistry? jObj = JsonSerializer.Deserialize<TokenizerRegistry>(json);

            if(jObj == null)
            {
                Console.Error.WriteLine($"Invalid Json found @{jsonFilePath}. Terminating tokenizer maps construction");
                return null;