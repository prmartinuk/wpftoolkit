﻿/************************************************************************

   Extended WPF Toolkit

   Copyright (C) 2010-2012 Xceed Software Inc.

   This program is provided to you under the terms of the Microsoft Public
   License (Ms-PL) as published at http://wpftoolkit.codeplex.com/license 

   This program can be provided to you by Xceed Software Inc. under a
   proprietary commercial license agreement for use in non-Open Source
   projects. The commercial version of Extended WPF Toolkit also includes
   priority technical support, commercial updates, and many additional 
   useful WPF controls if you license Xceed Business Suite for WPF.

   Visit http://xceed.com and follow @datagrid on Twitter.

  **********************************************************************/

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Specialized;
using System.Collections;
using System.Diagnostics;
using System.ComponentModel;

namespace Xceed.Utils.Collections
{
  [System.Diagnostics.CodeAnalysis.SuppressMessage( "Microsoft.Design", "CA1039:ListsAreStronglyTyped" )]
  [System.Diagnostics.CodeAnalysis.SuppressMessage( "Microsoft.Naming", "CA1710:IdentifiersShouldHaveCorrectSuffix" )]
  [System.Diagnostics.CodeAnalysis.SuppressMessage( "Microsoft.Design", "CA1035:ICollectionImplementationsHaveStronglyTypedMembers" )]
  public sealed class ReadOnlyObservableHashList : IList, ICollection, IEnumerable, INotifyCollectionChanged, INotifyPropertyChanged
  {
    public ReadOnlyObservableHashList()
    {
      m_hashList = new ObservableHashList();

      m_hashList.CollectionChanged += new NotifyCollectionChangedEventHandler( this.OnInnerCollectionChanged );
      m_hashList.PropertyChanged += new PropertyChangedEventHandler( this.OnInnerPropertyChanged );
    }

    #region IList Members

    public int Add( object value )
    {
      throw new InvalidOperationException( "An attempt was made to add an item to a read-only ObservableHashList." );
    }

    public void Clear()
    {
      throw new InvalidOperationException( "An attempt was made to clear a read-only ObservableHashList." );
    }

    public bool Contains( object value )
    {
      return m_hashList.Contains( value );
    }

    public int IndexOf( object value )
    {
      return m_hashList.IndexOf( value );
    }

    public void Insert( int index, object value )
    {
      throw new InvalidOperationException( "An attempt was made to insert an item into a read-only ObservableHashList." );
    }

    public bool IsFixedSize
    {
      get
      {
        return m_hashList.IsFixedSize;
      }
    }

    public bool IsReadOnly
    {
      get
      {
        return true;
      }
    }

    public void Remove( object value )
    {
      throw new InvalidOperationException( "An attempt was made to remove an item from a read-only ObservableHashList." );
    }

    public void RemoveAt( int index )
    {
      throw new InvalidOperationException( "An attempt was made to remove an item from a read-only ObservableHashList." );
    }

    public object this[ int index ]
    {
      get
      {
        return m_hashList[ index ];
      }
      set
      {
        throw new InvalidOperationException( "An attempt was made to replace an item in a read-only ObservableHashList." );
      }
    }

    #endregion

    #region ICollection Members

    public void CopyTo( Array array, int index )
    {
      m_hashList.CopyTo( array, index );
    }

    public int Count
    {
      get
      {
        return m_hashList.Count;
      }
    }

    public bool IsSynchronized
    {
      get
      {
        return m_hashList.IsSynchronized;
      }
    }

    public object SyncRoot
    {
      get
      {
        return m_hashList.SyncRoot;
      }
    }

    #endregion

    #region IEnumerable Members

    public IEnumerator GetEnumerator()
    {
      return m_hashList.GetEnumerator();
    }

    #endregion

    #region INotifyCollectionChanged Members

    public event NotifyCollectionChangedEventHandler CollectionChanged;

    private void OnCollectionChanged( NotifyCollectionChangedEventArgs args )
    {
      if( this.CollectionChanged != null )
        this.CollectionChanged( this, args );
    }

    #endregion

    #region INotifyPropertyChanged Members

    public event PropertyChangedEventHandler PropertyChanged;

    private void OnPropertyChanged( PropertyChangedEventArgs args )
    {
      if( this.PropertyChanged != null )
        this.PropertyChanged( this, args );
    }

    #endregion

    #region INTERNAL PROPERTIES

    internal ObservableHashList InnerObservableHashList
    {
      get
      {
        return m_hashList;
      }
    }


    #endregion

    #region PRIVATE METHODS

    private void OnInnerCollectionChanged( object sender, NotifyCollectionChangedEventArgs e )
    {
      this.OnCollectionChanged( e );
    }

    private void OnInnerPropertyChanged( object sender, PropertyChangedEventArgs e )
    {
      this.OnPropertyChanged( e );
    }

    #endregion

    #region PRIVATE FIELDS

    private ObservableHashList m_hashList; // = null

    #endregion
  }
}