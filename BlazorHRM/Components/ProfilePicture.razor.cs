using System;
using Microsoft.AspNetCore.Components;

namespace BlazorHRM.Components
{
  public partial class ProfilePicture
  {
    [Parameter]
    public RenderFragment? ChildContent { get; set; }
  }
}

