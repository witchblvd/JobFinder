﻿using System.Diagnostics;
using MongoDB.Bson.Serialization.Attributes;

namespace TelegramBot.Models;
[BsonIgnoreExtraElements]
public class UserSettings : ISetting
{
    private string _city { get; set; }
    private string _job { get; set; }
    
    private string _category;

    [BsonElement("UserId")]
    public long UserId { get; set; }
    
    [BsonElement("SiteName")]
    public string SiteName { get; set; }
    
    [BsonElement("Path")]
    public string Path { get; set; }

    [BsonElement("Job")]
    public string Job
    {
        get => _job;
        set
        {
            switch (SiteName)
            {
                case var s when s.Contains("Rabota"):
                    if (value == "")
                    {
                        value = "";
                    }
                    _job = value;
                    switch (value)
                    {
                        case var x when x.Contains('#'):
                            _job = _job.Replace("#", "%2523");
                            break;
                        case var x when x.Contains('+'):
                            _job = _job.Replace("+", "%252B");
                            break;
                        case var x when x.Contains(" "):
                            _job = _job.Replace(" ", "-");
                            break;
                    }
                    Path = Path + $"{_job}";
                    break;
                case var s when s.Contains("Work"):
                    if (value == "")
                    {
                        value = "";
                    }
                    _job = value;
                    switch (value)
                    {
                        case var x when x.Contains('#'):
                            _job = _job.Replace("#", "%23");
                            break;
                        case var x when x.Contains('+'):
                            _job = _job.Replace("+", "%2B");
                            break;
                        case var x when x.Contains(" "):
                            _job = _job.Replace(" ", "+");
                            break;
                    }
                    Path = Path + $"{_job}/";
                    break;
                case var s when s.Contains("Dou"):
                    if (value == "")
                    {
                        value = "";
                    }
                    _job = value;
                        switch (value)
                        {
                            case var x when x.Contains('#'):
                                _job = _job.Replace("#", "%23");
                                break;
                            case var x when x.Contains('+'):
                                _job = _job.Replace("+", "%2B");
                                break;
                            case var x when x.Contains(" "):
                                _job = _job.Replace(" ", "+");
                                break;
                        }
                        Path = Path + $"search={_job}";
                    
                        _job = "";
                    
                    break;
            }

        }
    }

    [BsonElement("Category")]
    public string Category 
    {
        get => _category;
        set
        {
            switch (SiteName)
            {
                case var s when s.Contains("Rabota"):
                    if(value != "")
                    {
                        _category = "";
                    }
                    break;
                case var s when s.Contains("Work"):
                    if(value != null)
                        Path = Path + $"search={_category = value}";
                    else
                    {
                        _category = "";
                    }
                    break;
                case var s when s.Contains("Dou"):
                    if(value != null)
                        Path = Path + $"search={_category = value}";
                    else
                    {
                        _category = "";
                    }
                    break;
            }

        }
    }
    
    [BsonElement("City")]
    public string City 
    {
        get => _city;
        set
        {
            switch (SiteName)
            {
                case var s when s.Contains("Rabota"):
                    if(value != null)
                        Path = Path + $"/{_city = value}";
                    break;
                case var s when s.Contains("Work"):
                    Path = Path + $"{_city = value}-";
                    break;
                case var s when s.Contains("Dou"):
                    Path = Path + $"?city={_city = value}&";
                    break;
            }

        }
    }
    
    [BsonElement("XCard")]
    public string XCard { get; set; } 
    [BsonElement("XPublished")]
    public string XPublished { get; set; } 

    public bool Complete { get; set; } = false;
}