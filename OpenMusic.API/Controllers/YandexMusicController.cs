using Microsoft.AspNetCore.Mvc;
using OpenMusic.API.Models;
using Yandex.Music.Api;
using Yandex.Music.Api.Common;
using Yandex.Music.Api.Models.Account;
using Yandex.Music.Api.Models.Track;
using Yandex.Music.Client;

namespace OpenMusic.API.Controllers;


[ApiController]
[Route("[controller]")]
public class YandexMusicController : Controller
{
    private YandexMusicClient _client;
    private YandexMusicApi _api;
    public YandexMusicController(ILogger<WeatherForecastController> logger)
    {
        _client = new YandexMusicClient();
        _api = new YandexMusicApi();
        _client.Authorize("", "");
    }

    [HttpGet]
    [Route("GetSongById")]
    public MySong GetSongById(string idSong)
    {
        YTrack yTrack = _client.GetTrack(idSong);
        var data = _api.Track.ExtractData(yTrack.Context.Storage, idSong);
        return new MySong { Name = yTrack.Title, Author = yTrack.Artists[0].Name, Data = data};
    }
    
    [HttpGet]
    [Route("GetBytesById")]
    public byte[] GetBytesById(string idSong)
    {
        YTrack yTrack = _client.GetTrack(idSong);
        var data = _api.Track.ExtractData(yTrack.Context.Storage, idSong);
        return data;
    }
    
    [HttpGet]
    [Route("GetHello")]
    public string GetHello()
    {
        return "Hello";
    }
}
