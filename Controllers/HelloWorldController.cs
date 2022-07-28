using Microsoft.AspNetCore.Mvc;
using webapi;

namespace mywebapi.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class HelloWorldController : ControllerBase{

    IHelloWorldService helloWorldService;
    private readonly ILogger<HelloWorldController> _logger;
    TareasContext dbcontext;
     
    public HelloWorldController(ILogger<HelloWorldController> logger,IHelloWorldService helloworld, TareasContext db)
    {
        _logger = logger;
        helloWorldService = helloworld;
        dbcontext = db;
    }

    [HttpGet]
    public IActionResult Get()
    {
        _logger.LogInformation("Saludando el mundo");
        return Ok(helloWorldService.GetHelloWorld()); 
    }

    [HttpGet]
    [Route("createdb")]
    public IActionResult CreateDatabase()
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        dbcontext.Database.EnsureCreated();
        return Ok();
    }

}