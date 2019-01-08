# cave-progress

Cave.Progress is a small and simple threadsafe, multi progress management solution.

## Package

A package is available at [**nuget.org**](https://www.nuget.org/packages/Cave.Progress)

## Master

The primary repo for the project is on [GitHub](https://github.com/Dingsd4/cave-progress) and this is where the [wiki](https://github.com/Dingsd4/cave-progress/wiki) and [issues](https://github.com/Dingsd4/cave-progress/issues) are managed from.

## Licence

All original software is licensed under the [LGPL-3 Licence](https://github.com/Dingsd4/cave-progress/blob/master/LICENSE). This does not apply to any other 3rd party tools, utilities or code which may be used to develop this application.

If anyone is aware of any licence violations that this code may be making please inform the developers so that the issue can be investigated and rectified.

## Building

You will need:

1. Visual Studio VS2017 (Community Edition) or later
2. Target Framework packs:
    * netstandard1.3
    * netstandard2.0
    * netcoreapp1.0
    * netcoreapp2.0
    * net20
    * net35
    * net40
    * net45
    * net46
    * net47

## First use

To start your first progress try the following code

```csharp
var progress = ProgressManager.CreateProgress();
progress.Update(0, "Some work");
for(int i = 0; i < 1000; i++)
{
    //do some work
    Thread.Sleep(100);
    progress.Update(i / 1000.0f);
}
progress.Complete();
```

By using the ```ProgressManager.Updated``` event handler you can write your progress display.

For example a simple console title updater:

```csharp
ProgressManager.Updated += (sender, e) => Console.Title = e.Progress.ToString();
```

or code updating a Windows Forms ProgressBar

```csharp
ProgressManager.Updated += (sender, e) =>
{
    //since this event may be called by another thread (the one updating the progress) we need to invoke
    formProgress.Invoke((Action)delegate
    {
        if (e.Progress.Completed)
        {
            formProgress.Close();
            MessageBox.Show($"{e.Progress.Text} has completed!");
        }
        else
        {
            formProgress.progressBar1.Value = (int)(e.Progress.Value * 100);
        }
    });
}
```
