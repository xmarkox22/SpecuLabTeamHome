-- Eliminar primero las tablas dependientes (hijas)
DROP TABLE IF EXISTS [ManagementBudgets];
DROP TABLE IF EXISTS [Transactions];
DROP TABLE IF EXISTS [Requests];
DROP TABLE IF EXISTS [Apartments];

-- Luego eliminar las tablas principales (padres)
DROP TABLE IF EXISTS [Statuses];
DROP TABLE IF EXISTS [Buildings];
DROP TABLE IF EXISTS [TransactionsTypes];