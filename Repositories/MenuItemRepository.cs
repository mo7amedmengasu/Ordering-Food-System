using Db_Project.models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Db_Project.Repositories
{
    public class MenuItemRepository
    {
        private readonly DatabaseHelper _dbHelper;
        private const string TableName = "MenuItem"; 

        public MenuItemRepository(string connectionString)
        {
            _dbHelper = new DatabaseHelper(connectionString);
        }

        // INSERT - Add new menu item
        public int AddMenuItem(MenuItem1 menuItem)
        {
            if (menuItem == null)
                throw new ArgumentNullException(nameof(menuItem));

            string query = $@"
                INSERT INTO {TableName} 
                (Name, Availability, Price, Description, RestaurantID)
                OUTPUT INSERTED.ItemID
                VALUES (@Name, @Availability, @Price, @Description, @RestaurantID)";

            SqlParameter[] parameters =
            {
                new SqlParameter("@Name", menuItem.Name ?? (object)DBNull.Value),
                new SqlParameter("@Availability", menuItem.Availability),
                new SqlParameter("@Price", menuItem.Price),
                new SqlParameter("@Description", menuItem.Description ?? (object)DBNull.Value),
                new SqlParameter("@RestaurantID", menuItem.RestaurantID)
            };

            return Convert.ToInt32(_dbHelper.ExecuteScalar(query, parameters));
        }

        // GET BY ID - Get menu item by ID
        public MenuItem1 GetMenuItemById(int itemId)
        {
            string query = $@"
                SELECT * 
                FROM {TableName} 
                WHERE ItemID = @ItemID";

            SqlParameter[] parameters = { new SqlParameter("@ItemID", itemId) };

            DataTable dataTable = _dbHelper.ExecuteQuery(query, parameters);
            return dataTable.Rows.Count > 0 ? MapDataRowToMenuItem(dataTable.Rows[0]) : null;
        }

        // GET ALL - Get all menu items
        public List<MenuItem1> GetAllMenuItems()
        {
            string query = $@"SELECT * FROM {TableName}";
            DataTable dataTable = _dbHelper.ExecuteQuery(query);
            return MapDataTableToMenuItems(dataTable);
        }

        // GET BY RESTAURANT - Get menu items by restaurant
        public List<MenuItem1> GetMenuItemsByRestaurant(int restaurantId)
        {
            string query = $@"
                SELECT * 
                FROM {TableName} 
                WHERE RestaurantID = @RestaurantID
                ORDER BY Name";

            SqlParameter[] parameters = { new SqlParameter("@RestaurantID", restaurantId) };
            DataTable dataTable = _dbHelper.ExecuteQuery(query, parameters);
            return MapDataTableToMenuItems(dataTable);
        }

        // GET AVAILABLE ITEMS - Get only available menu items
        public List<MenuItem1> GetAvailableMenuItems(int restaurantId)
        {
            string query = $@"
                SELECT * 
                FROM {TableName} 
                WHERE RestaurantID = @RestaurantID AND Availability = 1
                ORDER BY Name";

            SqlParameter[] parameters = { new SqlParameter("@RestaurantID", restaurantId) };
            DataTable dataTable = _dbHelper.ExecuteQuery(query, parameters);
            return MapDataTableToMenuItems(dataTable);
        }

        // UPDATE - Update menu item
        public void UpdateMenuItem(MenuItem1 menuItem)
        {
            if (menuItem == null)
                throw new ArgumentNullException(nameof(menuItem));

            string query = $@"
                UPDATE {TableName} 
                SET Name = @Name,
                    Availability = @Availability,
                    Price = @Price,
                    Description = @Description,
                    RestaurantID = @RestaurantID
                WHERE ItemID = @ItemID";

            SqlParameter[] parameters =
            {
                new SqlParameter("@ItemID", menuItem.ItemID),
                new SqlParameter("@Name", menuItem.Name ?? (object)DBNull.Value),
                new SqlParameter("@Availability", menuItem.Availability),
                new SqlParameter("@Price", menuItem.Price),
                new SqlParameter("@Description", menuItem.Description ?? (object)DBNull.Value),
                new SqlParameter("@RestaurantID", menuItem.RestaurantID)
            };

            _dbHelper.ExecuteNonQuery(query, parameters);
        }

        // UPDATE AVAILABILITY - Toggle item availability
        public void UpdateAvailability(int itemId, bool isAvailable)
        {
            string query = $@"
                UPDATE {TableName} 
                SET Availability = @Availability
                WHERE ItemID = @ItemID";

            SqlParameter[] parameters =
            {
                new SqlParameter("@ItemID", itemId),
                new SqlParameter("@Availability", isAvailable)
            };

            _dbHelper.ExecuteNonQuery(query, parameters);
        }

        // DELETE - Remove menu item
        public void DeleteMenuItem(int itemId)
        {
            string query = $@"
                DELETE FROM {TableName} 
                WHERE ItemID = @ItemID";

            SqlParameter[] parameters = { new SqlParameter("@ItemID", itemId) };
            _dbHelper.ExecuteNonQuery(query, parameters);
        }

        // PRIVATE HELPER METHODS
        private MenuItem1 MapDataRowToMenuItem(DataRow row)
        {
            return new MenuItem1
            {
                ItemID = (int)row["ItemID"],
                Name = row["Name"].ToString(),
                Availability = Convert.ToBoolean(row["Availability"]),
                Price = Convert.ToDecimal(row["Price"]),
                Description = row["Description"]?.ToString(),
                RestaurantID = (int)row["RestaurantID"]
            };
        }

        private List<MenuItem1> MapDataTableToMenuItems(DataTable dataTable)
        {
            List<MenuItem1> menuItems = new List<MenuItem1>();
            foreach (DataRow row in dataTable.Rows)
            {
                menuItems.Add(MapDataRowToMenuItem(row));
            }
            return menuItems;
        }
    }
}
