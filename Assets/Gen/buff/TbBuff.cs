//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using Bright.Serialization;
using System.Collections.Generic;
using System.Linq;

namespace cfg.buff
{
   
    public partial class TbBuff
    {
        public static TbBuff Instance { get; private set; }
        private bool _readAllList = false;
        private List<buff.Buff> _dataList;
        public List<buff.Buff> DataList
        {
            get
            {
                if(!_readAllList)
                {
                    ReadAllList();
                    _readAllList = true;
                }
                return _dataList;
            }
        }
        private System.Func<ByteBuf> _dataLoader;

        private bool _readAll;
        private Dictionary<(int, int), buff.Buff> _dataMapUnion;
        public Dictionary<(int, int), buff.Buff> DataMapUnion
        {
            get
            {
                if(!_readAll)
                {
                    ReadAll();
                    _readAll = true;
                }
                return _dataMapUnion;
            }            
        }
        private void ReadAll()
        {
            foreach(var index in Indexes)
            {
                var (Id, Level) = index;
                var v = Get(Id, Level);
                _dataMapUnion[(Id, Level)] = v;
            }
        }
        private void ReadAllList()
        {
            _dataList.Clear();
            foreach(var index in Indexes)
            {
                var (Id, Level) = index;
                var v = Get(Id, Level);
                _dataList.Add(v);
            }
        }
        private Dictionary<(int Id, int Level),int> _indexMap;
        public List<(int Id, int Level)> Indexes;
        
        public TbBuff(ByteBuf _buf, string _tbName, System.Func<string,  ByteBuf> _loader)
        {
            Instance = this;
            _dataList = new List<buff.Buff>();
            _dataLoader = new System.Func<ByteBuf>(()=> _loader(_tbName));
            _dataMapUnion = new Dictionary<(int, int), buff.Buff>();
            _indexMap = new Dictionary<(int Id, int Level),int>();
            
            for (int i = _buf.ReadSize(); i > 0; i--)
            {
                
                int key0;
                key0 = _buf.ReadInt();
                
                
                int key1;
                key1 = _buf.ReadInt();
                
                _indexMap.Add((key0, key1), _buf.ReadInt());
            }
            Indexes = _indexMap.Keys.ToList();
        }



        public buff.Buff Get(int Id, int Level)
        {
            buff.Buff __v;
            if(_dataMapUnion.TryGetValue((Id, Level), out __v))
            {
                return __v;
            }
            ResetByteBuf(_indexMap[(Id, Level)]);

            __v = buff.Buff.DeserializeBuff(_buf);
            _dataList.Add(__v);
            _dataMapUnion.Add((Id, Level), __v);
            __v.Resolve(tables);
            if(_indexMap.Count == _dataMapUnion.Count)
            {
                _buf = null;
            }
            return __v;
        }
        
        private void ResetByteBuf(int readerInex = 0)
        {
            if( _buf == null)
            {
                    if (_buf == null)
            {
                _buf = _dataLoader();
            }
            }
            _buf.ReaderIndex = readerInex;
        }
    
        private ByteBuf _buf = null;
        private Dictionary<string, object> tables;
        public void CacheTables(Dictionary<string, object> _tables)
        {
            tables = _tables;
        }
        partial void PostInit();
    }
} 