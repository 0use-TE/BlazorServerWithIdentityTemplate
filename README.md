# [Englist& 英文文档](/docs/en.md)
# 🚀 BlazorServer With Identity 模板 / Template

## 👋 中文介绍

你好，我是 **Ouse**，欢迎查看本仓库！  

本仓库提供一个 **Blazor Server 项目模板**，集成了以下功能：

- 🛠 Web API 支持  
- 🔐 Identity 认证系统  
- 🗄 EF Core（使用 SQLite）  
- 🎨 UI 风格使用 MudBlazor  
- 🔑 基础登录和登出功能  

### ❓ 为什么需要集成 Web API？

Blazor Server 基于 **SignalR 实时通信**，所有组件交互都是通过 SignalR 完成，没有传统的 HTTP 请求-响应模式，因此无法直接设置 Cookie，这给登录和登出带来了问题。  

解决方案主要有两种：

1. **集成 Web API**：Blazor Server 通过 `NavigationManager` 或 JS 发起请求，由 API 设置 Cookie。  
2. **集成 Razor Pages**：认证相关页面使用 Razor Pages，Blazor Server 只负责业务界面。  

第二种方式不够优雅，并且 Razor Pages 与 Blazor Server 混合会增加项目复杂度，因此模板选择了 **第一种方案**。

## ⚡ 中文使用教程

1. 打开终端/命令行  
2. 安装模板：

```bash
dotnet new install BlazorServerWithIdentityTemplate
```
创建新项目：

```bash
dotnet new blazorserverwithidentity -n YourProjectName
```
进入项目目录：

```bash
cd YourProjectName
```
运行项目：
```bash
dotnet run
```
📝 中文其他说明
默认使用 Server 全局交互模式，可根据需求调整。

默认数据库是 SQLite，如果需要使用其它数据库，请修改 ApplicationDbContext 的配置