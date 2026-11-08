## 简介

本项目仅用于学习如何在 Unity 中使用 PureMVC 框架完成 UI 相关功能的实现，使用该框架的目的是为了**解耦**。当面对大型的项目或者具有复杂 UI 内容的游戏时，使用 PureMVC 框架虽然增加了脚本数量，但是能清晰地展现逻辑，方便团队的小伙伴们合作。 
本项目先跟着 **唐老狮** 的视频完成了以下不同方式的实现：**不使用MVC实现简单的UI功能**，**使用MVC实现**，**使用优化后的MVC——MVX实现**，**使用PureMVC框架实现**。然后我在简单地做了一个小练习来巩固我的知识。

---

## 文件介绍

- _PracticeResources ： 练习时使用到的资源，一些图片，图片来源可见文件 kenny_ui_pack。
- _PracticeScripts ： 练习时创建的脚本，用来巩固知识的。
- Art ： 唐老狮视频中的资源包，包括一些 UI 资源。
- Resources ： 使用代码动态加载的资源，Resources/UI 文件夹下是唐老狮拼好的面板，Resources/Practice 文件夹下是我用于练习随手拼的面板。
- Scenes ： 场景文件夹，SampleScene 是跟着教程做的；Practice 是我用来巩固知识的。
- Scripts ： 脚本文件，/Normal 文件夹是不使用 MVC 思想完成 UI 控件的脚本； /MVC 文件夹是使用 MVC 思想完成 UI 控件的脚本； /MVX 文件夹是优化后的脚本，例如 /MVX/MVP 和 /MVX/MP(MVVM)； /PureMVC 文件夹是使用 PureMVC 框架的脚本； /ProjectBase 是唐老狮的程序基础框架，在里面的 /ProjectBase/PureMVC 文件夹是从 网站上获取的 pureMVC C# 源码。

---

## 使用需知

如果使用 /Scripts/Normal 的脚本，请打开 SampleScene，将 `NormalMain.cs` 拖拽到主摄像机上，确保摄像机只添加了这个脚本；然后将 `MainPanel.cs`和`RolePanel.cs`分别拖到`MainPanel`和`RolePanel`预制体上，也确保这两个面板预制体没有添加其他重复脚本。在 Inspector 面板里，手动将面板的控件拖到脚本中。

如果使用 /Scripts/MVC 的脚本，还是在 SampleScene中，将`Test.cs`拖拽到摄像机上，确保摄像机只添加了这个脚本；然后将`MainView.cs`和`RoleView.cs`分别拖到`MainPanel`和`RolePanel`预制体上，在 Inspector 面板里，手动将面板的控件拖到脚本中。

如果使用 /Scripts/MVX/MVP 的脚本，将 `MVPTest.cs`拖到摄像机上，确保摄像机只添加了这个脚本；然后将`MVP_MainView.cs`和`MVP_RoleView.cs`分别拖到`MainPanel`和`RolePanel`预制体上，在 Inspector 面板里，手动将面板的控件拖到脚本中。

如果使用 /Scripts/MVX/MP(MVVM) 的脚本，将 `MPTest.cs`拖到摄像机上，确保摄像机只添加了这个脚本；然后将`MP_MainView.cs`和`MP_RoleView.cs`分别拖到`MainPanel`和`RolePanel`预制体上，获取控件的过程封装在 UIManager 中了。

如果使用 /Scripts/PureMVC 的脚本，将 `Main.cs`拖到摄像机上；然后将`NewMainView.cs`和`NewRoleView.cs`分别拖到`MainPanel`和`RolePanel`预制体上，在 Inspector 面板里，手动将面板的控件拖到脚本中。

---

如果使用 /_PracticeScripts的脚本，打开 Practice 场景；将`P_Main.cs`拖到摄像机上；将`Practice_SampleView`拖到  Resources 中的 `Practice_SamplePanel` 预制体上，手动将控件拖到脚本中。

## 关于 PureMVC 框架的个人理解

可见文章 [Unity中运用PureMVC框架](https://turokfang.top/posts/06Nov2026.html)
