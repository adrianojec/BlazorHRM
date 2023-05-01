using System;
using BlazorHRM.State;
using Microsoft.AspNetCore.Components;

namespace BlazorHRM.Components
{
  public partial class InboxCounter
  {
    [Inject]
    public AppState? AppState { get; set; }

    private int MessageCount;

    protected override void OnInitialized()
    {
      MessageCount = new Random().Next(10);
      AppState.MessageCount = MessageCount;
    }
  }
}

