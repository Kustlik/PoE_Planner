using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PoE_Planner
{
    public class PoeNinjaPost
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("next_change_id")]
        public string NextChangeId { get; set; }
        [JsonProperty("api_bytes_downloaded")]
        public long ApiBytesDownloaded { get; set; }
        [JsonProperty("stash_tabs_processed")]
        public long StashTabsProcessed { get; set; }
        [JsonProperty("api_calls")]
        public long ApiCalls { get; set; }
        [JsonProperty("character_bytes_downloaded")]
        public long CharacterBytesDownloaded { get; set; }
        [JsonProperty("character_api_calls")]
        public long CharacterApiCalls { get; set; }
        [JsonProperty("ladder_bytes_downloaded")]
        public long LadderBytesDownloaded { get; set; }
        [JsonProperty("ladder_api_calls")]
        public long LadderApiCalls { get; set; }
        [JsonProperty("pob_characters_calculated")]
        public long PobCharactersCalculated { get; set; }
    }
}
