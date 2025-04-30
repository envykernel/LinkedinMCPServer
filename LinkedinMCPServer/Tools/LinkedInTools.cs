using ModelContextProtocol.Server;
using System.ComponentModel;
using System.Net.Http.Json;
using System.Text.Json;

namespace LinkedinMCPServer.Tools;

[McpServerToolType]
public static class LinkedInTools
{

    [McpServerTool, Description("Search for jobs on LinkedIn.")]
    public static async Task<string> SearchJobs(
        HttpClient client,
        [Description("Keywords to search for in job titles and descriptions.")] string keywords,
        [Description("Location ID for the search (e.g., 105015875 for France).")] string locationId = "105015875",
        [Description("When the job was posted (anyTime, past24Hours, pastWeek, pastMonth).")] string datePosted = "anyTime",
        [Description("Sort order (mostRelevant, mostRecent).")] string sort = "mostRelevant")
    {
        var queryString = $"search-jobs-v2?keywords={Uri.EscapeDataString(keywords)}&locationId={locationId}&datePosted={datePosted}&sort={sort}";
        var response = await client.GetFromJsonAsync<JsonElement>(queryString);

        if (!response.GetProperty("success").GetBoolean())
        {
            return $"Error: {response.GetProperty("message").GetString()}";
        }

        var jobs = response.GetProperty("data").EnumerateArray();
        var total = response.GetProperty("total").GetInt32();

        if (!jobs.Any())
        {
            return "No jobs found matching your criteria.";
        }

        return string.Join("\n---\n", jobs.Select(job => $"""
                Title: {job.GetProperty("title").GetString()}
                Company: {job.GetProperty("company").GetProperty("name").GetString()}
                Location: {job.GetProperty("location").GetString()}
                Posted: {job.GetProperty("postAt").GetString()}
                URL: {job.GetProperty("url").GetString()}
                """)) + $"\n\nTotal results: {total}";
    }
}