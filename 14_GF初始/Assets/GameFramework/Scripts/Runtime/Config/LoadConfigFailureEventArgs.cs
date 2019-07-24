﻿//------------------------------------------------------------
// Game Framework
// Copyright © 2013-2019 Jiang Yin. All rights reserved.
// Homepage: http://gameframework.cn/
// Feedback: mailto:jiangyin@gameframework.cn
//------------------------------------------------------------

using GameFramework;
using GameFramework.Event;

namespace UnityGameFramework.Runtime
{
    /// <summary>
    /// 加载配置失败事件。
    /// </summary>
    public sealed class LoadConfigFailureEventArgs : GameEventArgs
    {
        /// <summary>
        /// 加载配置失败事件编号。
        /// </summary>
        public static readonly int EventId = typeof(LoadConfigFailureEventArgs).GetHashCode();

        /// <summary>
        /// 获取加载配置失败事件编号。
        /// </summary>
        public override int Id
        {
            get
            {
                return EventId;
            }
        }

        /// <summary>
        /// 获取配置名称。
        /// </summary>
        public string ConfigName
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取配置资源名称。
        /// </summary>
        public string ConfigAssetName
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取配置加载方式。
        /// </summary>
        public LoadType LoadType
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取错误信息。
        /// </summary>
        public string ErrorMessage
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取用户自定义数据。
        /// </summary>
        public object UserData
        {
            get;
            private set;
        }

        /// <summary>
        /// 清理加载配置失败事件。
        /// </summary>
        public override void Clear()
        {
            ConfigName = default(string);
            ConfigAssetName = default(string);
            LoadType = default(LoadType);
            ErrorMessage = default(string);
            UserData = default(object);
        }

        /// <summary>
        /// 填充加载配置失败事件。
        /// </summary>
        /// <param name="e">内部事件。</param>
        /// <returns>加载配置失败事件。</returns>
        public LoadConfigFailureEventArgs Fill(GameFramework.Config.LoadConfigFailureEventArgs e)
        {
            LoadConfigInfo loadConfigInfo = (LoadConfigInfo)e.UserData;
            ConfigName = loadConfigInfo.ConfigName;
            ConfigAssetName = e.ConfigAssetName;
            LoadType = e.LoadType;
            ErrorMessage = e.ErrorMessage;
            UserData = loadConfigInfo.UserData;

            return this;
        }
    }
}
