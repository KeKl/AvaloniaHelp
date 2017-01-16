# AvaloniaHelp
A help framework for the [avalonia](https://github.com/AvaloniaUI/Avalonia/) project.

## NuGet

AvaloniaHelp will be delivered as a NuGet package. 

## Background

AvaloniaHelp is a help framework for the [avalonia](https://github.com/AvaloniaUI/Avalonia/) project. It is designed for creating a help for desktop or mobile applications.

## Current Status

Work in progress.

## Example
### Create topics
	var root = new Topic("root");
	provider.SetContent(root, "This is the root of the help.");
            
	var mainTopic1 = new Topic("root|main1");
	provider.SetContent(mainTopic1, "Main 1 help.");

	var subTopic1 = new Topic("root|main1|sub1", "Sub 1");
	provider.SetContent(subTopic1, "This is the sub1 help.");

### Create a toc
	var root = new Section("Test App Help");
	root.Topic = helpManager.Topics.FirstOrDefault(t => t.Keyword == "root");

	var mainSec1 = new Section("Main 2");
	mainSec1.Topic = helpManager.Topics.FirstOrDefault(t => t.Keyword == "root|main1");

	var subSec1 = new Section("Sub 1");
	subSec1.Topic = helpManager.Topics.FirstOrDefault(t => t.Keyword == "root|main1|sub1");
	mainSec1.AddSubSection(subSec1);

### Create the view

#### Set keywords for the controls
	<TextBox Text="Node 1" Help:HelpManager.Keyword="root|main1|sub1" />

#### Add a quick view
	<HelpViews:QuickHelpView />

#### Add a view with a toc
	<HelpViews:HelpView />