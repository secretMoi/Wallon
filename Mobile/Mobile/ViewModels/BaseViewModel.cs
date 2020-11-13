﻿using Mobile.Models;
using Mobile.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace Mobile.ViewModels
{
	public class BaseViewModel : INotifyPropertyChanged
	{
		public IDataStore<Item> DataStore => DependencyService.Get<IDataStore<Item>>();

		string _title = string.Empty;
		bool _isBusy;

		public bool IsBusy
		{
			get => _isBusy;
			set => SetProperty(ref _isBusy, value);
		}

		public string Title
		{
			get => _title;
			set => SetProperty(ref _title, value);
		}

		protected bool SetProperty<T>(ref T backingStore, T value,
			[CallerMemberName] string propertyName = "",
			Action onChanged = null)
		{
			if (EqualityComparer<T>.Default.Equals(backingStore, value))
				return false;

			backingStore = value;

			onChanged?.Invoke();

			OnPropertyChanged(propertyName);

			return true;
		}

		#region INotifyPropertyChanged
		public event PropertyChangedEventHandler PropertyChanged;
		protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
		{
			var changed = PropertyChanged;

			if (changed == null)
				return;

			changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
		#endregion
	}
}
