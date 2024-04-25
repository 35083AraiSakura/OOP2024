using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise1 {
    internal class Program {
        static void Main(string[] args) {
            var songs = new Song[] {
                new Song("I wanna! You wanna!","ROF-MAO",232),
                new Song("Mins Games","Sickick",260),
                new Song("EXCITE","Daichi Miura",187)
            };
            PrintSongs(songs);
        }

        private static void PrintSongs(Song[] songs) {
            foreach (var song in songs) {
                Console.WriteLine(@"{0} {1} {2:mm\:ss}", song.Title, song.ArtistName, TimeSpan.FromSeconds(song.Length));
            }

        }
    }
}
