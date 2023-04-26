using System;
namespace BlazorHRM.Components.Widgets
{
  public partial class InboxWidget
  {
    public int MessageCount { get; set; }

    protected override void OnInitialized()
    {
      MessageCount = new Random().Next(10);
    }
  }
}

