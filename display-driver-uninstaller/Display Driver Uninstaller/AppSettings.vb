﻿Imports System.IO
Imports System.Xml
Imports System.Windows
Imports System.Reflection
Imports System.Collections.ObjectModel

Public Enum GPUVendor
	Nvidia
	AMD
	Intel
End Enum

Public Class AppSettings
	Inherits DependencyObject

#Region "Private Fields"
	Private m_appname As DependencyProperty = Reg("AppName", GetType(String), GetType(AppSettings), "Display Driver Uninstaller (DDU)")
	Private m_languageOptions As ObservableCollection(Of Languages.LanguageOption)
	Private m_gpuSelected As DependencyProperty = Reg("SelectedGPU", GetType(GPUVendor), GetType(AppSettings), GPUVendor.Nvidia)

	' Removals
	Private m_remMonitors As DependencyProperty = Reg("RemoveMonitors", GetType(Boolean), GetType(AppSettings), False)

	Private m_remCrimsonCache As DependencyProperty = Reg("RemoveCrimsonCache", GetType(Boolean), GetType(AppSettings), False)
	Private m_remAMDDirs As DependencyProperty = Reg("RemoveAMDDirs", GetType(Boolean), GetType(AppSettings), False)
	Private m_remAMDAudioBus As DependencyProperty = Reg("RemoveAMDAudioBus", GetType(Boolean), GetType(AppSettings), False)
	Private m_remAMDKMPFD As DependencyProperty = Reg("RemoveAMDKMPFD", GetType(Boolean), GetType(AppSettings), False)

	Private m_remNvidiaDirs As DependencyProperty = Reg("RemoveNvidiaDirs", GetType(Boolean), GetType(AppSettings), False)
	Private m_remPhysX As DependencyProperty = Reg("RemovePhysX", GetType(Boolean), GetType(AppSettings), False)
	Private m_rem3DtvPlay As DependencyProperty = Reg("Remove3DTVPlay", GetType(Boolean), GetType(AppSettings), False)
	Private m_remGFE As DependencyProperty = Reg("RemoveGFE", GetType(Boolean), GetType(AppSettings), False)

	' Settings
	Private m_showSafeModeMsg As DependencyProperty = Reg("ShowSafeModeMsg", GetType(Boolean), GetType(AppSettings), False)
	Private m_UseRoamingCfg As DependencyProperty = Reg("UseRoamingConfig", GetType(Boolean), GetType(AppSettings), False)
	Private m_DontCheckUpdates As DependencyProperty = Reg("DontCheckUpdates", GetType(Boolean), GetType(AppSettings), False)
	Private m_createRestorePoint As DependencyProperty = Reg("CreateRestorePoint", GetType(Boolean), GetType(AppSettings), False)
	Private m_saveLogs As DependencyProperty = Reg("SaveLogs", GetType(Boolean), GetType(AppSettings), False)
#End Region

#Region "Public Properties"
	Public Property AppName As String ' Name of application (DDU)
		Get
			Return CStr(GetValue(m_appname))
		End Get
		Private Set(value As String)
			SetValue(m_appname, value)
		End Set
	End Property

	Public ReadOnly Property LanguageOptions As ObservableCollection(Of Languages.LanguageOption)
		Get
			Return m_languageOptions
		End Get
	End Property

	Public Property SelectedGPU As GPUVendor
		Get
			Return CType(GetValue(m_gpuSelected), GPUVendor)
		End Get
		Set(value As GPUVendor)
			SetValue(m_gpuSelected, value)
		End Set
	End Property

	Public Property RemoveMonitors As Boolean
		Get
			Return CBool(GetValue(m_remMonitors))
		End Get
		Set(value As Boolean)
			SetValue(m_remMonitors, value)
		End Set
	End Property

	Public Property RemoveCrimsonCache As Boolean
		Get
			Return CBool(GetValue(m_remCrimsonCache))
		End Get
		Set(value As Boolean)
			SetValue(m_remCrimsonCache, value)
		End Set
	End Property
	Public Property RemoveAMDDirs As Boolean
		Get
			Return CBool(GetValue(m_remAMDDirs))
		End Get
		Set(value As Boolean)
			SetValue(m_remAMDDirs, value)
		End Set
	End Property
	Public Property RemoveAMDAudioBus As Boolean
		Get
			Return CBool(GetValue(m_remAMDAudioBus))
		End Get
		Set(value As Boolean)
			SetValue(m_remAMDAudioBus, value)
		End Set
	End Property
	Public Property RemoveAMDKMPFD As Boolean
		Get
			Return CBool(GetValue(m_remAMDKMPFD))
		End Get
		Set(value As Boolean)
			SetValue(m_remAMDKMPFD, value)
		End Set
	End Property

	Public Property RemoveNvidiaDirs As Boolean
		Get
			Return CBool(GetValue(m_remNvidiaDirs))
		End Get
		Set(value As Boolean)
			SetValue(m_remNvidiaDirs, value)
		End Set
	End Property
	Public Property RemovePhysX As Boolean
		Get
			Return CBool(GetValue(m_remPhysX))
		End Get
		Set(value As Boolean)
			SetValue(m_remPhysX, value)
		End Set
	End Property
	Public Property Remove3DTVPlay As Boolean
		Get
			Return CBool(GetValue(m_rem3DtvPlay))
		End Get
		Set(value As Boolean)
			SetValue(m_rem3DtvPlay, value)
		End Set
	End Property
	Public Property RemoveGFE As Boolean
		Get
			Return CBool(GetValue(m_remGFE))
		End Get
		Set(value As Boolean)
			SetValue(m_remGFE, value)
		End Set
	End Property

	Public Property ShowSafeModeMsg As Boolean
		Get
			Return CBool(GetValue(m_showSafeModeMsg))
		End Get
		Set(value As Boolean)
			SetValue(m_showSafeModeMsg, value)
		End Set
	End Property
	Public Property UseRoamingConfig As Boolean
		Get
			Return CBool(GetValue(m_UseRoamingCfg))
		End Get
		Set(value As Boolean)
			SetValue(m_UseRoamingCfg, value)
		End Set
	End Property
	Public Property DontCheckUpdates As Boolean
		Get
			Return CBool(GetValue(m_DontCheckUpdates))
		End Get
		Set(value As Boolean)
			SetValue(m_DontCheckUpdates, value)
		End Set
	End Property
	Public Property CreateRestorePoint As Boolean
		Get
			Return CBool(GetValue(m_createRestorePoint))
		End Get
		Set(value As Boolean)
			SetValue(m_createRestorePoint, value)
		End Set
	End Property
	Public Property SaveLogs As Boolean
		Get
			Return CBool(GetValue(m_saveLogs))
		End Get
		Set(value As Boolean)
			SetValue(m_saveLogs, value)
		End Set
	End Property
#End Region

	Friend Shared Function Reg(ByVal s As String, ByVal t As Type, ByVal c As Type, ByVal m As Object) As DependencyProperty
		' Register values for 'Binding' (just shorthand, Don't need to undestand)
		If TypeOf (m) Is FrameworkPropertyMetadata Then
			Return DependencyProperty.Register(s, t, c, CType(m, FrameworkPropertyMetadata))
		Else
			Return DependencyProperty.Register(s, t, c, New PropertyMetadata(m))
		End If
	End Function

	Public Sub New()
		m_languageOptions = New ObservableCollection(Of Languages.LanguageOption)()
	End Sub

	Public Sub Load(ByVal fileName As String)

	End Sub

	Public Sub Save(ByVal fileName As String)

	End Sub

End Class
