using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace ProtectedApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ValuesController : ControllerBase
    {
        private readonly string _ownerName = "Warren I. Albino"; 

        [HttpGet("about/me")]
        public IActionResult GetAboutMe()
        {
            var randomFacts = GenerateRandomFacts();
            return Ok(randomFacts);
        }

        [HttpGet("about")]
        public IActionResult GetAbout()
        {
            return Ok(new { CreatorName = "Warren I. Albino" }); 
        }

        [HttpPost("about")]
        public IActionResult PostAbout([FromBody] AboutRequest request)
        {
            var greetingMessage = $"Hi {request.Name} from {_ownerName}";
            return Ok(new { Greeting = greetingMessage });
        }

        private List<string> GenerateRandomFacts()
        {
            var random = new Random();
            var randomFacts = new List<string>
            {
                "Introverted.",
                "I like programming",
                "I spend most of my time playing video games",
                "I can't sleep forcibly",
                "I'm a Night Person",
                "When I get my first paycheck, the first thing I will buy outside of basic necessities is an AC",
                "One of my biggest issue is procrastination",
                "The current anime that I follow is JJK",
                "I have kidney problems (due to overconsumption of soda and genetics)",
                "Managing people is very hard for me. But I like to get out of my comfort zone for some change."
            };

            // Shuffle the random facts
            for (int i = randomFacts.Count - 1; i > 0; i--)
            {
                int j = random.Next(i + 1);
                var temp = randomFacts[i];
                randomFacts[i] = randomFacts[j];
                randomFacts[j] = temp;
            }

            return randomFacts;
        }
    }

    public class AboutRequest
    {
        public string Name { get; set; }
    }
}
