using System.Net.Mail;

namespace DarkDhamon.RazorEmailTemplate.TemplateEngine;

public interface IRazorTemplateEngine
{
    string GetMvcRazorHtmlString(string area, string controller, string action);
    string GetRazorPageHtmlString(string area, string page);
}