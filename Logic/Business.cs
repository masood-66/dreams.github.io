using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using Islamic_Dreams.Models;
using Islamic_Dreams.Session;
using DbConnection = Islamic_Dreams.Models.DbConnection;

namespace Islamic_Dreams.Logic
{
	public static class Business
	{




		public static APP_USERS Authenticate(string username, string passwd)
		{
			using (var db = new DbConnection())
			{
				var user = db.APP_USERS.FirstOrDefault(s => s.USERNAME == username && s.PASSWORD == passwd);
				if (user == null)
					return null;
				var session = new Management();
				session.Set(user);
				return user;
			}
		}

        

        public static bool Add(IMAM_INFO imamInfo)
		{
			try
			{
				using (var db = new DbConnection())
				{
					var k = db.IMAM_INFO.FirstOrDefault(s => s.IMAM_ENG == imamInfo.IMAM_ENG || s.IMAM_URDU == imamInfo.IMAM_URDU);
					if (k == null)
					{
						db.IMAM_INFO.Add(imamInfo);
						db.SaveChanges();
						return true;
					}

					return false;
				}
			}
			catch (Exception e)
			{
				return false;
			}
		}
		public static bool Add(INDEX_TABLE index)
		{
			try
			{
				using (var db = new DbConnection())
				{
					var k = db.INDEX_TABLE.FirstOrDefault(s => s.INDEX_ENGLISH == index.INDEX_ENGLISH || s.INDEX_URDU == index.INDEX_URDU);
					if (k == null)
					{
						db.INDEX_TABLE.Add(index);
						db.SaveChanges();
						return true;
					}
					else
					{
						k.TOTAL_COUNT = k.TOTAL_COUNT + 1;
						db.SaveChanges();
						return false;
						k.INDEX_ENGLISH = index.INDEX_ENGLISH;
						k.INDEX_URDU = index.INDEX_URDU;
						db.SaveChanges();
						return true;
					}
					return false;
				}
			}
			catch (Exception e)
			{
				return false;
			}
		}
		public static bool Add(BOOKS_INFO book)
		{
			try
			{
				using (var db = new DbConnection())
				{
					var k = db.BOOKS_INFO.FirstOrDefault(s => s.BOOK_ENG == book.BOOK_ENG || s.BOOK_URDU == book.BOOK_URDU);
					if (k == null)
					{
						db.BOOKS_INFO.Add(book);
						db.SaveChanges();
						return true;
					}

					return false;
				}
			}
			catch (Exception e)
			{
				return false;
			}
		}
		public static bool Add(KEY_WORDS key)
		{
			try
			{
				using (var db = new DbConnection())
				{
					var k = db.KEY_WORDS.FirstOrDefault(s => s.KEY_ENGLISH == key.KEY_ENGLISH && s.FK_BOOK_REF == key.FK_BOOK_REF || s.KEY_URDU == key.KEY_URDU && s.FK_BOOK_REF == key.FK_BOOK_REF);
					if (k == null)
					{
						db.KEY_WORDS.Add(key);
						db.SaveChanges();
						Add(new INDEX_TABLE
						{
							INDEX_ENGLISH = key.KEY_ENGLISH,
							INDEX_URDU = key.KEY_URDU,
							INDEX_STATUS = true,
						});

						return true;
					}

					return false;
				}
			}
			catch (Exception e)
			{
				return false;
			}
		}

		public static bool Add(DATA_SETS dataset)
		{
			try
			{
				using (var db = new DbConnection())
				{
					//var k = db.DATA_SETS.FirstOrDefault(s => s.DATA_ENGLISH == dataset.DATA_ENGLISH || s.DATA_URDU == dataset.DATA_URDU);
					//if (k == null)
					{
						db.DATA_SETS.Add(dataset);
						db.SaveChanges();
						return true;
					}

					return false;
				}
			}
			catch (Exception e)
			{
				return false;
			}
		}

		public static bool Update(DATA_SETS dataset)
		{
			try
			{
				using (var db = new DbConnection())
				{
					var set = db.DATA_SETS.FirstOrDefault(s => s.DATA_ID == dataset.DATA_ID);
					if (set != null)
					{
						set.DATA_ENGLISH = dataset.DATA_ENGLISH;
						set.DATA_URDU = dataset.DATA_URDU;
						if (dataset.FK_KEY_CODE != 0)
							set.FK_KEY_CODE = dataset.FK_KEY_CODE;
						if (dataset.FK_IMAM_CODE != null)
							set.FK_IMAM_CODE = dataset.FK_IMAM_CODE;

						db.SaveChanges();
						return true;
					}
					return false;
				}
			}
			catch (Exception e)
			{
				return false;
			}
		}

		public static bool Update(KEY_WORDS word)
		{
			try
			{
				using (var db = new DbConnection())
				{
					var keyWord = db.KEY_WORDS.FirstOrDefault(s => s.KEY_CODE == word.KEY_CODE);
					if (keyWord != null)
					{
						keyWord.KEY_ENGLISH = word.KEY_ENGLISH;
						keyWord.KEY_URDU = word.KEY_URDU;

						db.SaveChanges();
						return true;
					}
					return false;
				}
			}
			catch (Exception e)
			{
				return false;
			}
		}

		public static bool Update(INDEX_TABLE word)
		{
			try
			{
				using (var db = new DbConnection())
				{
					var index = db.INDEX_TABLE.FirstOrDefault(s => s.INDEX_ID == word.INDEX_ID);
					if (index != null)
					{
						index.INDEX_ENGLISH = word.INDEX_ENGLISH;
						index.INDEX_URDU = word.INDEX_URDU;

						db.SaveChanges();
						return true;
					}
					return false;
				}
			}
			catch (Exception e)
			{
				return false;
			}
		}

		public static bool Update(BOOKS_INFO book)
		{
			try
			{
				using (var db = new DbConnection())
				{
					var k = db.BOOKS_INFO.First(s => s.BOOK_ID == book.BOOK_ID);
					k.BOOK_ENG = book.BOOK_ENG;
					k.BOOK_URDU = book.BOOK_URDU;
					db.SaveChanges();
					return true;
				}
			}
			catch (Exception e)
			{
				return false;
			}
		}

		public static bool Update(IMAM_INFO imamInfo)
		{
			try
			{
				using (var db = new DbConnection())
				{
					var k = db.IMAM_INFO.First(s => s.IMAM_ID == imamInfo.IMAM_ID);
					k.IMAM_ENG = imamInfo.IMAM_ENG;
					k.IMAM_URDU = imamInfo.IMAM_URDU;
					db.SaveChanges();
					return true;
				}
			}
			catch (Exception e)
			{
				return false;
			}
		}

		public static bool Delete(DATA_SETS set)
		{
			try
			{
				using (var db = new DbConnection())
				{
					db.DATA_SETS.Remove(db.DATA_SETS.First(s => s.DATA_ID == set.DATA_ID));
					db.SaveChanges();
					return true;
				}
			}
			catch (Exception e)
			{
				return false;
			}
		}

		public static bool Delete(KEY_WORDS word)
		{
			try
			{
				using (var db = new DbConnection())
				{
					db.KEY_WORDS.Remove(db.KEY_WORDS.First(s => s.KEY_CODE == word.KEY_CODE));
					db.SaveChanges();
					return true;
				}
			}
			catch (Exception e)
			{
				return false;
			}
		}

		public static List<V_KEYWORDS> GetKeyWords(int? BookID)
		{
			using (var db = new DbConnection())
			{
				if (BookID != null)
					return db.V_KEYWORDS.Where(s => s.BOOK_ID == BookID).ToList();
				return db.V_KEYWORDS.ToList();
			}
		}
		public static KEY_WORDS GetKeyWord(int KEY_CODE)
		{
			using (var db = new DbConnection())
			{
				return db.KEY_WORDS.First(s => s.KEY_CODE == KEY_CODE);
			}
		}

		public static INDEX_TABLE GetIndex(int INDEX_ID)
		{
			using (var db = new DbConnection())
			{
				return db.INDEX_TABLE.First(s => s.INDEX_ID == INDEX_ID);
			}
		}

		public static DATA_SETS GetDream(int? DATA_ID)
		{
			using (var db = new DbConnection())
			{
				return db.DATA_SETS.First(s => s.DATA_ID == DATA_ID);
			}
		}
		public static V_DREAMS_DATA GetCompleteDream(int? DATA_ID)
		{
			using (var db = new DbConnection())
			{
				return db.V_DREAMS_DATA.First(s => s.DATA_ID == DATA_ID);
			}
		}

		public static List<V_DREAMS_DATA> GetCatalog(int? BookID)
		{
			using (var db = new DbConnection())
			{
				if (BookID != null)
					return db.V_DREAMS_DATA.Where(s => s.BOOK_ID == BookID).ToList();
				return db.V_DREAMS_DATA.ToList();
			}
		}

		public static List<V_DREAMS_DATA> GetDreamsCatalog(int? BookID, int? KEY_CODE, int? Imam)
		{
			using (var db = new DbConnection())
			{
				var q = db.V_DREAMS_DATA.AsQueryable();
				if (BookID != null)
					q = q.Where(s => s.BOOK_ID == BookID);
				if (KEY_CODE != null)
					q = q.Where(s => s.KEY_CODE == KEY_CODE);
				if (Imam != null)
					q = q.Where(s => s.IMAM_ID == Imam);
				return q.ToList();
			}
		}

		public static List<BOOKS_INFO> GetBooks()
		{
			using (var db = new DbConnection())
			{
				return db.BOOKS_INFO.ToList();
			}
		}

		public static List<INDEX_TABLE> GetIndexs()
		{
			using (var db = new DbConnection())
			{
				return db.INDEX_TABLE.ToList();
			}
		}




		public static List<IMAM_INFO> GetImams()
		{
			using (var db = new DbConnection())
			{

				var x = db.IMAM_INFO.ToList();
				x.Add(new IMAM_INFO
				{
					IMAM_ENG = "Select Imam ",
					IMAM_URDU = "منتخب کریں",
					IMAM_ID = 0,
				});
				return x.OrderBy(s => s.IMAM_ID).ToList();
			}
		}

		public static bool DeleteImam(int IMAM_ID)
		{
			try
			{
				using (var db = new DbConnection())
				{
					db.IMAM_INFO.Remove(db.IMAM_INFO.First(s => s.IMAM_ID == IMAM_ID));
					db.SaveChanges();
					return true;
				}
			}
			catch (Exception e)
			{
				return false;
			}
		}
		public static bool DeleteBook(int BOOK_ID)
		{
			try
			{
				using (var db = new DbConnection())
				{
					db.BOOKS_INFO.Remove(db.BOOKS_INFO.First(s => s.BOOK_ID == BOOK_ID));
					db.SaveChanges();
					return true;
				}
			}
			catch (Exception e)
			{
				return false;
			}
		}

		public static bool DeleteKeyword(int KEY_CODE)
		{
			try
			{
				using (var db = new DbConnection())
				{
					db.KEY_WORDS.Remove(db.KEY_WORDS.First(s => s.KEY_CODE == KEY_CODE));
					db.SaveChanges();
					return true;
				}
			}
			catch (Exception e)
			{
				return false;
			}
		}

		public static bool DeleteIndex(int INDEX_ID)
		{
			try
			{
				using (var db = new DbConnection())
				{
					db.INDEX_TABLE.Remove(db.INDEX_TABLE.First(s => s.INDEX_ID == INDEX_ID));
					db.SaveChanges();
					return true;
				}
			}
			catch (Exception e)
			{
				return false;
			}
		}

		public static bool DeleteDream(int DATA_ID)
		{
			try
			{
				using (var db = new DbConnection())
				{
					db.DATA_SETS.Remove(db.DATA_SETS.First(s => s.DATA_ID == DATA_ID));
					db.SaveChanges();
					return true;
				}
			}
			catch (Exception e)
			{
				return false;
			}
		}

		public static IMAM_INFO GetImam(int IMAM_ID)
		{
			using (var db = new DbConnection())
			{
				return db.IMAM_INFO.First(s => s.IMAM_ID == IMAM_ID);
			}
		}


		public static BOOKS_INFO GetBook(int BOOK_ID)
		{
			using (var db = new DbConnection())
			{
				return db.BOOKS_INFO.First(s => s.BOOK_ID == BOOK_ID);
			}
		}

		public static DATA_SETS GetDataSet(int DATA_ID)
		{
			using (var db = new DbConnection())
			{
				return db.DATA_SETS.First(s => s.DATA_ID == DATA_ID);
			}
		}

		public static List<DreamsByBook> GetDreamByKeyword(string search,bool isEnglish)
		{
			using (var db = new DbConnection())
			{
				if (string.IsNullOrEmpty(search))
					return null;
				var words = search.Split(' ').ToList();
				var exclude = GetExclusionList(isEnglish);
				foreach (var exc in exclude)
				{
					words.Remove(exc);
				}

				var list = new List<DreamsByBook>();
				foreach (var word in words)
				{
					var data = db.V_DREAMS_DATA.Where(s => s.DATA_URDU.Contains(word)).ToList();

					if (data.Count < 1)
						if (word.Length >= 3)
							Logic.Business.Add(new INDEX_TABLE
							{
								INDEX_URDU = word,
								INDEX_ENGLISH = word,
								INDEX_STATUS = false,

							});

					foreach (var itm in data.Select(s => s.BOOK_URDU).Distinct().ToList())
					{
						list.Add(new DreamsByBook
						{
							Book = itm,
							Dreams = data.Where(s => s.BOOK_URDU == itm).ToList().Select(v => new DropDown
							{
								Text = v.DATA_URDU,
								Value = v.DATA_ID,
							}).ToList(),
						});
					}
				}
				return list;
			}
		}
		public static List<DreamsByAuthor> GetDreamsByAuthor(string search, bool isEnglish)
		{
			using (var db = new DbConnection())
			{
				if (string.IsNullOrEmpty(search))
					return null;
				var words = search.Split(' ').ToList();
				var exclude = GetExclusionList(isEnglish);
				foreach (var exc in exclude)
				{
					words.Remove(exc.Trim());
				}

				var list = new List<DreamsByAuthor>();
				foreach (var word in words)
				{
					var data = db.V_DREAMS_DATA.Where(s => s.DATA_URDU.Contains(word)).ToList();

					if (data.Count < 1)
						if (word.Length >= 3)
							Logic.Business.Add(new INDEX_TABLE
							{
								INDEX_URDU = word,
								INDEX_ENGLISH = word,
								INDEX_STATUS = false,

							});

					foreach (var itm in data.Select(s => s.IMAM_URDU).Distinct().ToList())
					{
						list.Add(new DreamsByAuthor
						{
							Author = itm,
							Dreams = data.Where(s => s.IMAM_URDU == itm).ToList().Select(v => new DropDown
							{
								Text = v.DATA_URDU,
								Value = v.DATA_ID,
							}).ToList(),
						});
					}
				}
				return list;
			}
		}

		public static List<DreamsByAuthor> GetDreamsByAuthorEnglish(string search)
		{
			using (var db = new DbConnection())
			{
				if (string.IsNullOrEmpty(search))
					return null;
				var words = search.Split(' ').ToList();
				var exclude = GetExclusionList(true);
				foreach (var exc in exclude)
				{
					words.Remove(exc.Trim());
				}

				var list = new List<DreamsByAuthor>();
				foreach (var word in words)
				{
					var data = db.V_DREAMS_DATA.Where(s => s.DATA_ENGLISH.Contains(word)).ToList();

					if (data.Count < 1)
						if (word.Length >= 3)
							Logic.Business.Add(new INDEX_TABLE
							{
								INDEX_URDU = word,
								INDEX_ENGLISH = word,
								INDEX_STATUS = false,

							});

					foreach (var itm in data.Select(s => s.IMAM_ENG).Distinct().ToList())
					{
						list.Add(new DreamsByAuthor
						{
							Author = itm,
							Dreams = data.Where(s => s.IMAM_ENG == itm).ToList().Select(v => new DropDown
							{
								Text = v.DATA_ENGLISH,
								Value = v.DATA_ID,
							}).ToList(),
						});
					}
				}
				return list;
			}
		}

		public static List<V_KEYWORDS> GetKeyWordByBook(int FK_BOOK_REF)
		{
			using (var db = new DbConnection())
			{
				return db.V_KEYWORDS.Where(s => s.FK_BOOK_REF == FK_BOOK_REF).ToList();
			}
		}
		public static List<KEY_WORDS> GetKeyword(int? BooId)
		{
			using (var db = new DbConnection())
			{
				if (BooId != null)
					return db.KEY_WORDS.Where(s => s.FK_BOOK_REF == BooId).ToList();
				return db.KEY_WORDS.ToList();

			}
		}

		public static bool ToggleIndex(int INDEX_ID)
		{

			try
			{
				using (var db = new DbConnection())
				{
					var index = db.INDEX_TABLE.First(s => s.INDEX_ID == INDEX_ID);
					index.INDEX_STATUS = index.INDEX_STATUS == null || index.INDEX_STATUS == false;
					db.SaveChanges();
					return true;
				}
			}
			catch (Exception e)
			{
				return false;
			}
		}

		public static List<string> GetExclusionList(bool isEnglish)
		{
			try
			{
				using (var db = new DbConnection())
				{
					return db.EXCLUTION_LIST.Where(s=>s.IS_ENGLISH==isEnglish).Select(s => s.EXCLUTION_TEXT).ToList();
				}
			}
			catch (Exception e)
			{
				return new List<string>();
			}
		}
	}
}