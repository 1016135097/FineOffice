﻿
#region Comment

/*
 * Project：    FineUI
 * 
 * FileName:    Alert.cs
 * CreatedOn:   2008-04-07
 * CreatedBy:   30372245@qq.com
 * 
 * 
 * Description：
 *      ->
 *   
 * History：
 *       
 *      ->2008-04-30    30372245@qq.com    改为静态帮助类
 * 
 * 
 * 
 */

#endregion

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace FineUI
{
    /// <summary>
    /// 提示对话框帮助类
    /// </summary>
    public class Alert
    {
        #region public static

        public static MessageBoxIcon DefaultMessageBoxIcon = MessageBoxIcon.Information;

        #endregion

        #region class

        private string _message;

        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }

        private string _title;

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        private MessageBoxIcon _messageBoxIcon = DefaultMessageBoxIcon;

        public MessageBoxIcon MessageBoxIcon
        {
            get { return _messageBoxIcon; }
            set { _messageBoxIcon = value; }
        }

        private string _okScript;

        public string OkScript
        {
            get { return _okScript; }
            set { _okScript = value; }
        }

        private Target _target;

        public Target Target
        {
            get { return _target; }
            set { _target = value; }
        }

        private string _iconUrl;

        public string IconUrl
        {
            get { return _iconUrl; }
            set { _iconUrl = value; }
        }

        private Icon _icon = Icon.None;

        public Icon Icon
        {
            get { return _icon; }
            set { _icon = value; }
        }


        /// <summary>
        /// 显示提示对话框
        /// </summary>
        public void Show()
        {
            Show(Message, Title, MessageBoxIcon, OkScript, Target, Icon, IconUrl);
        }

        /// <summary>
        /// 获取显示提示对话框的客户端脚本
        /// </summary>
        /// <returns></returns>
        public string GetShowReference()
        {
            return GetShowReference(Message, Title, MessageBoxIcon, OkScript, Target, Icon, IconUrl);
        }

        #endregion

        #region static Show

        /// <summary>
        /// 显示提示对话框
        /// </summary>
        /// <param name="message"></param>
        public static void Show(string message)
        {
            Show(message, String.Empty, DefaultMessageBoxIcon, String.Empty);
        }

        /// <summary>
        /// 显示提示对话框
        /// </summary>
        /// <param name="message"></param>
        /// <param name="title"></param>
        public static void Show(string message, string title)
        {
            Show(message, title, DefaultMessageBoxIcon, String.Empty);
        }

        /// <summary>
        /// 显示提示对话框
        /// </summary>
        /// <param name="message"></param>
        /// <param name="icon"></param>
        public static void Show(string message, MessageBoxIcon icon)
        {
            Show(message, String.Empty, icon, String.Empty);
        }

        public static void Show(string message, string title, string okScript)
        {
            Show(message, title, DefaultMessageBoxIcon, okScript);
        }

        public static void Show(string message, string title, MessageBoxIcon icon)
        {
            Show(message, title, icon, String.Empty);
        }

        /// <summary>
        /// 显示提示对话框
        /// </summary>
        /// <param name="message"></param>
        /// <param name="title"></param>
        /// <param name="icon"></param>
        public static void Show(string message, string title, MessageBoxIcon icon, string okScript)
        {
            PageContext.RegisterStartupScript(GetShowReference(message, title, icon, okScript));
        }

        public static void Show(string message, string title, MessageBoxIcon icon, string okScript, Target target)
        {
            PageContext.RegisterStartupScript(GetShowReference(message, title, icon, okScript, target));
        }

        public static void Show(string message, string title, MessageBoxIcon messageBoxIcon, string okScript, Target target, Icon icon, string iconUrl)
        {
            PageContext.RegisterStartupScript(GetShowReference(message, title, messageBoxIcon, okScript, target, icon, iconUrl));
        }

        #endregion

        #region static ShowInParent

        /// <summary>
        /// 在父页面中显示提示对话框
        /// </summary>
        /// <param name="message"></param>
        public static void ShowInParent(string message)
        {
            ShowInParent(message, String.Empty, DefaultMessageBoxIcon, String.Empty);
        }

        /// <summary>
        /// 在父页面中显示提示对话框
        /// </summary>
        /// <param name="message"></param>
        /// <param name="title"></param>
        public static void ShowInParent(string message, string title)
        {
            ShowInParent(message, title, DefaultMessageBoxIcon, String.Empty);
        }

        /// <summary>
        /// 在父页面中显示提示对话框
        /// </summary>
        /// <param name="message"></param>
        /// <param name="icon"></param>
        public static void ShowInParent(string message, MessageBoxIcon icon)
        {
            ShowInParent(message, String.Empty, icon, String.Empty);
        }

        public static void ShowInParent(string message, string title, string okScript)
        {
            ShowInParent(message, title, DefaultMessageBoxIcon, okScript);
        }

        public static void ShowInParent(string message, string title, MessageBoxIcon icon)
        {
            ShowInParent(message, title, icon, String.Empty);
        }

        /// <summary>
        /// 在父页面中显示提示对话框
        /// </summary>
        /// <param name="message"></param>
        /// <param name="title"></param>
        /// <param name="icon"></param>
        public static void ShowInParent(string message, string title, MessageBoxIcon icon, string okScript)
        {
            PageContext.RegisterStartupScript(GetShowInParentReference(message, title, icon, okScript));
        }

        #endregion

        #region static ShowInTop

        /// <summary>
        /// 在顶层窗口中显示提示对话框
        /// </summary>
        /// <param name="message"></param>
        public static void ShowInTop(string message)
        {
            ShowInTop(message, String.Empty, DefaultMessageBoxIcon, String.Empty);
        }

        /// <summary>
        /// 在顶层窗口中显示提示对话框
        /// </summary>
        /// <param name="message"></param>
        /// <param name="title"></param>
        public static void ShowInTop(string message, string title)
        {
            ShowInTop(message, title, DefaultMessageBoxIcon, String.Empty);
        }

        /// <summary>
        /// 在顶层窗口中显示提示对话框
        /// </summary>
        /// <param name="message"></param>
        /// <param name="icon"></param>
        public static void ShowInTop(string message, MessageBoxIcon icon)
        {
            ShowInTop(message, String.Empty, icon, String.Empty);
        }

        public static void ShowInTop(string message, string title, string okScript)
        {
            ShowInTop(message, title, DefaultMessageBoxIcon, okScript);
        }

        public static void ShowInTop(string message, string title, MessageBoxIcon icon)
        {
            ShowInTop(message, title, icon, String.Empty);
        }

        /// <summary>
        /// 在顶层窗口中显示提示对话框
        /// </summary>
        /// <param name="message"></param>
        /// <param name="title"></param>
        /// <param name="icon"></param>
        public static void ShowInTop(string message, string title, MessageBoxIcon icon, string okScript)
        {
            PageContext.RegisterStartupScript(GetShowInTopReference(message, title, icon, okScript));
        }

        #endregion

        #region static GetShowReference

        /// <summary>
        /// 获取显示提示对话框的客户端脚本
        /// </summary>
        /// <param name="message">对话框消息</param>
        /// <returns>客户端脚本</returns>
        public static string GetShowReference(string message)
        {
            return GetShowReference(message, String.Empty, DefaultMessageBoxIcon);
        }

        /// <summary>
        /// 获取显示提示对话框的客户端脚本
        /// </summary>
        /// <param name="message">对话框消息</param>
        /// <param name="title">对话框标题</param>
        /// <returns>客户端脚本</returns>
        public static string GetShowReference(string message, string title)
        {
            return GetShowReference(message, title, DefaultMessageBoxIcon);
        }

        /// <summary>
        /// 获取显示提示对话框的客户端脚本
        /// </summary>
        /// <param name="message">对话框消息</param>
        /// <param name="icon">对话框图标</param>
        /// <returns>客户端脚本</returns>
        public static string GetShowReference(string message, MessageBoxIcon icon)
        {
            return GetShowReference(message, String.Empty, icon);
        }

        /// <summary>
        /// 获取显示提示对话框的客户端脚本
        /// </summary>
        /// <param name="message">对话框消息</param>
        /// <param name="title">对话框标题</param>
        /// <param name="icon">对话框图标</param>
        /// <returns>客户端脚本</returns>
        public static string GetShowReference(string message, string title, MessageBoxIcon icon)
        {
            return GetShowReference(message, title, icon, String.Empty);
        }

        /// <summary>
        /// 获取显示提示对话框的客户端脚本
        /// </summary>
        /// <param name="message">对话框消息</param>
        /// <param name="title">对话框标题</param>
        /// <param name="okScript">点击确定按钮执行的客户端脚本</param>
        /// <returns>客户端脚本</returns>
        public static string GetShowReference(string message, string title, string okScript)
        {
            return GetShowReference(message, title, DefaultMessageBoxIcon, okScript);
        }

        /// <summary>
        /// 获取显示提示对话框的客户端脚本
        /// </summary>
        /// <param name="message">对话框消息</param>
        /// <param name="title">对话框标题</param>
        /// <param name="icon">对话框图标</param>
        /// <param name="okScript">点击确定按钮执行的客户端脚本</param>
        /// <returns>客户端脚本</returns>
        public static string GetShowReference(string message, string title, MessageBoxIcon icon, string okScript)
        {
            return GetShowReference(message, title, icon, okScript, Target.Self);
        }

        /// <summary>
        /// 获取显示提示对话框的客户端脚本
        /// </summary>
        /// <param name="message">对话框消息</param>
        /// <param name="title">对话框标题</param>
        /// <param name="icon">对话框图标</param>
        /// <param name="okScript">点击确定按钮执行的客户端脚本</param>
        /// <param name="target">显示对话框的目标页面</param>
        /// <returns>客户端脚本</returns>
        public static string GetShowReference(string message, string title, MessageBoxIcon icon, string okScript, Target target)
        {
            return GetShowReference(message, title, icon, okScript, target, Icon.None, null);
        }

        /// <summary>
        /// 获取显示提示对话框的客户端脚本
        /// </summary>
        /// <param name="message">对话框消息</param>
        /// <param name="title">对话框标题</param>
        /// <param name="messageBoxIcon">对话框图标</param>
        /// <param name="okScript">点击确定按钮执行的客户端脚本</param>
        /// <param name="target">显示对话框的目标页面</param>
        /// <returns>客户端脚本</returns>
        public static string GetShowReference(string message, string title, MessageBoxIcon messageBoxIcon, string okScript, Target target, Icon icon, string iconUrl)
        {
            if (message == null)
            {
                message = String.Empty;
            }
            if (title == null)
            {
                title = String.Empty;
            }

            string addCSSScript = String.Empty;
            string iconScriptFragment = String.Empty;
            string resolvedIconUrl = IconHelper.GetResolvedIconUrl(icon, iconUrl);

            Page page = HttpContext.Current.CurrentHandler as Page;
            if (page != null)
            {
                resolvedIconUrl = page.ResolveUrl(resolvedIconUrl);
            }

            // Icon 或者 IconUrl 不为空
            if (!String.IsNullOrEmpty(resolvedIconUrl))
            {
                string className = String.Format("fineui_{0}_alert_icon", System.Guid.NewGuid().ToString("N"));

                var addCSSPrefix = String.Empty;
                if (target == Target.Parent)
                {
                    addCSSPrefix = "parent.";
                }
                else if (target == Target.Top)
                {
                    addCSSPrefix = "top.";
                }
                addCSSScript = String.Format("{0}X.util.addCSS('{1}','{2}');", addCSSPrefix, className, StyleUtil.GetNoRepeatBackgroundStyle("." + className, resolvedIconUrl));

                iconScriptFragment = String.Format("'{0}'", className);
            }
            else
            {
                iconScriptFragment = MessageBoxIconHelper.GetName(messageBoxIcon);
            }

            message = message.Replace("\r\n", "\n").Replace("\n", "<br/>");
            title = title.Replace("\r\n", "\n").Replace("\n", "<br/>");
            string targetScript = "window";
            if (target != Target.Self)
            {
                targetScript = TargetHelper.GetScriptName(target);
            }

            if (String.IsNullOrEmpty(title) &&
                messageBoxIcon == DefaultMessageBoxIcon &&
                String.IsNullOrEmpty(okScript) &&
                String.IsNullOrEmpty(resolvedIconUrl))
            {
                return addCSSScript + String.Format("{0}.X.alert({1});", targetScript, JsHelper.GetJsString(message));
            }
            else
            {
                return addCSSScript + String.Format("{0}.X.alert({1},{2},{3},{4});",
                    targetScript,
                    JsHelper.GetJsStringWithScriptTag(message),
                    JsHelper.GetJsString(title),
                    iconScriptFragment,
                    String.IsNullOrEmpty(okScript) ? "''" : JsHelper.GetFunction(okScript));
            }
        }
        #endregion

        #region static GetShowInParentReference

        /// <summary>
        /// 获取在父页面中显示提示对话框的客户端脚本
        /// </summary>
        /// <param name="message">对话框消息</param>
        /// <returns>客户端脚本</returns>
        public static string GetShowInParentReference(string message)
        {
            return GetShowInParentReference(message, String.Empty, DefaultMessageBoxIcon);
        }

        /// <summary>
        /// 获取在父页面中显示提示对话框的客户端脚本
        /// </summary>
        /// <param name="message">对话框消息</param>
        /// <param name="title">对话框标题</param>
        /// <returns>客户端脚本</returns>
        public static string GetShowInParentReference(string message, string title)
        {
            return GetShowInParentReference(message, title, DefaultMessageBoxIcon);
        }

        /// <summary>
        /// 获取在父页面中显示提示对话框的客户端脚本
        /// </summary>
        /// <param name="message">对话框消息</param>
        /// <param name="icon">对话框图标</param>
        /// <returns>客户端脚本</returns>
        public static string GetShowInParentReference(string message, MessageBoxIcon icon)
        {
            return GetShowInParentReference(message, String.Empty, icon);
        }

        /// <summary>
        /// 获取在父页面中显示提示对话框的客户端脚本
        /// </summary>
        /// <param name="message">对话框消息</param>
        /// <param name="title">对话框标题</param>
        /// <param name="icon">对话框图标</param>
        /// <returns>客户端脚本</returns>
        public static string GetShowInParentReference(string message, string title, MessageBoxIcon icon)
        {
            return GetShowInParentReference(message, title, icon, String.Empty);
        }

        /// <summary>
        /// 获取在父页面中显示提示对话框的客户端脚本
        /// </summary>
        /// <param name="message">对话框消息</param>
        /// <param name="title">对话框标题</param>
        /// <param name="okScript">点击确定按钮执行的客户端脚本</param>
        /// <returns>客户端脚本</returns>
        public static string GetShowInParentReference(string message, string title, string okScript)
        {
            return GetShowInParentReference(message, title, DefaultMessageBoxIcon, okScript);
        }

        /// <summary>
        /// 获取在父页面中显示提示对话框的客户端脚本
        /// </summary>
        /// <param name="message">对话框消息</param>
        /// <param name="title">对话框标题</param>
        /// <param name="icon">对话框图标</param>
        /// <param name="okScript">点击确定按钮执行的客户端脚本</param>
        /// <returns>客户端脚本</returns>
        public static string GetShowInParentReference(string message, string title, MessageBoxIcon icon, string okScript)
        {
            return GetShowReference(message, title, icon, okScript, Target.Parent);
        }

        #endregion

        #region static GetShowInTopReference

        /// <summary>
        /// 获取在最上层页面中显示提示对话框的客户端脚本
        /// </summary>
        /// <param name="message">对话框消息</param>
        /// <returns>客户端脚本</returns>
        public static string GetShowInTopReference(string message)
        {
            return GetShowInTopReference(message, String.Empty, DefaultMessageBoxIcon);
        }

        /// <summary>
        /// 获取在最上层页面中显示提示对话框的客户端脚本
        /// </summary>
        /// <param name="message">对话框消息</param>
        /// <param name="title">对话框标题</param>
        /// <returns>客户端脚本</returns>
        public static string GetShowInTopReference(string message, string title)
        {
            return GetShowInTopReference(message, title, DefaultMessageBoxIcon);
        }

        /// <summary>
        /// 获取在最上层页面中显示提示对话框的客户端脚本
        /// </summary>
        /// <param name="message">对话框消息</param>
        /// <param name="icon">对话框图标</param>
        /// <returns>客户端脚本</returns>
        public static string GetShowInTopReference(string message, MessageBoxIcon icon)
        {
            return GetShowInTopReference(message, String.Empty, icon);
        }

        /// <summary>
        /// 获取在最上层页面中显示提示对话框的客户端脚本
        /// </summary>
        /// <param name="message">对话框消息</param>
        /// <param name="title">对话框标题</param>
        /// <param name="icon">对话框图标</param>
        /// <returns>客户端脚本</returns>
        public static string GetShowInTopReference(string message, string title, MessageBoxIcon icon)
        {
            return GetShowInTopReference(message, title, icon, String.Empty);
        }

        /// <summary>
        /// 获取在最上层页面中显示提示对话框的客户端脚本
        /// </summary>
        /// <param name="message">对话框消息</param>
        /// <param name="title">对话框标题</param>
        /// <param name="okScript">点击确定按钮执行的客户端脚本</param>
        /// <returns>客户端脚本</returns>
        public static string GetShowInTopReference(string message, string title, string okScript)
        {
            return GetShowInTopReference(message, title, DefaultMessageBoxIcon, okScript);
        }

        /// <summary>
        /// 获取在最上层页面中显示提示对话框的客户端脚本
        /// </summary>
        /// <param name="message">对话框消息</param>
        /// <param name="title">对话框标题</param>
        /// <param name="icon">对话框图标</param>
        /// <param name="okScript">点击确定按钮执行的客户端脚本</param>
        /// <returns>客户端脚本</returns>
        public static string GetShowInTopReference(string message, string title, MessageBoxIcon icon, string okScript)
        {
            return GetShowReference(message, title, icon, okScript, Target.Top);
        }

        #endregion

    }
}
