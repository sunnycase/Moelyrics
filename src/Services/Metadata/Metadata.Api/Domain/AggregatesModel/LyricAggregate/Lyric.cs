using Moelyrics.Web.Domain.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Moelyrics.Web.Domain.AggregatesModel.LyricAggregate
{
    public class Lyric : Entity, IAggregateRoot
    {
        private int _trackId;
        public int Reliability { get; private set; }
        public string LrcFileName { get; private set; }

        protected Lyric() { }

        public Lyric(int trackId, string lrcFileName, int reliability = 0)
        {
            _trackId = trackId;
            LrcFileName = lrcFileName;
            Reliability = reliability;
        }

        public void SetReliability(int reliability)
        {
            Reliability = reliability;
        }
    }
}
