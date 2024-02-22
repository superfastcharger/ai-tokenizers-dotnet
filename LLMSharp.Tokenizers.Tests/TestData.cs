
﻿namespace LLMSharp.Tokenizers.Tests
{
    internal class TestData
    {
        internal const string OpenAiPluginsDocumentation = @"Consider implementing rate limiting on the API endpoints you expose. ChatGPT will respect 429 response codes and dynamically back off from sending requests to your plugin after receiving a certain number of 429's or 500's in a short period of time.

Timeouts
When making API calls during the plugin experience, timeouts take place if the following thresholds are exceeded:

15 seconds round trip for fetching ai-plugin.json/openapi.yaml
45 seconds round trip for API calls
As we scale the plugin experience to more people, we expect that the timeout thresholds will decrease.

Updating your plugin
Manifest files must be manually updated by going through the ""Develop your own plugin"" flow in the plugin store each time you make a change to the ai-plugin.json file. ChatGPT will automatically fetch the latest OpenAPI spec each time a request is made so changes made will propagate to end users immediately. If your plugin is available in the ChatGPT plugin store and you go through the ""Develop your own plugin"" flow, we will automatically look for changes in the files and remove the plugin if it has changed. You will have to resubmit your plugin to be included in the store again.

Plugin terms
In order to register a plugin, you must agree to the Plugin Terms.

Domain verification and security
To ensure that plugins can only perform actions on resources that they control, OpenAI enforces requirements on the plugin's manifest and API specifications.

Defining the plugin's root domain
The manifest file defines information shown to the user (like logo and contact information) as well as a URL where the plugin's OpenAPI spec is hosted. When the manifest is fetched, the plugin's root domain is established following these rules:

If the domain has www. as a subdomain, then the root domain will strip out www. from the domain that hosts the manifest.
Otherwise, the root domain is the same as the domain that hosts the manifest.
Note on redirects: If there are any redirects in resolving the manifest, only child subdomain redirects are allowed. The only exception is following a redirect from a www subdomain to one without the www.

Examples of what the root domain looks like:

✅ https://example.com/.well-known/ai-plugin.json
Root domain: example.com
✅ https://www.example.com/.well-known/ai-plugin.json
Root domain: example.com
✅ https://www.example.com/.well-known/ai-plugin.json → redirects to https://example.com/.well-known/ai-plugin.json
Root domain: example.com
✅ https://foo.example.com/.well-known/ai-plugin.json → redirects to https://bar.foo.example.com/.well-known/ai-plugin.json
Root domain: bar.foo.example.com
✅ https://foo.example.com/.well-known/ai-plugin.json → redirects to https://bar.foo.example.com/baz/ai-plugin.json
Root domain: bar.foo.example.com
❌ https://foo.example.com/.well-known/ai-plugin.json → redirects to https://example.com/.well-known/ai-plugin.json
Redirect to parent level domain is disallowed
❌ https://foo.example.com/.well-known/ai-plugin.json → redirects to https://bar.example.com/.well-known/ai-plugin.json
Redirect to same level subdomain is disallowed
❌ https://example.com/.well-known/ai-plugin.json -> redirects to https://example2.com/.well-known/ai-plugin.json
Redirect to another domain is disallowed
Manifest validation
Specific fields in the manifest itself must satisfy the following requirements:

api.url - the URL provided to the OpenAPI spec must be hosted at the same level or a subdomain of the root domain.
legal_info - The second-level domain of the URL provided must be the same as the second-level domain of the root domain.
contact_info - The second-level domain of the email address should be the same as the second-level domain of the root domain.
Resolving the API spec