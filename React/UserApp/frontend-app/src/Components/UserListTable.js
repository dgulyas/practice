import Table from '@mui/material/Table';
import TableBody from '@mui/material/TableBody';
import TableCell from '@mui/material/TableCell';
import TableContainer from '@mui/material/TableContainer';
import TableHead from '@mui/material/TableHead';
import TableRow from '@mui/material/TableRow';
import Paper from '@mui/material/Paper';
import Checkbox from '@mui/material/Checkbox';


function UserListTable({users}){
	return (
		<div>
			<TableContainer component={Paper}>
				<Table sx={{ minWidth: 500 }} size="small">
					<TableHead>
						<TableRow>
							<TableCell />
							<TableCell>First Name</TableCell>
							<TableCell>Last Name</TableCell>
						</TableRow>
					</TableHead>
					<TableBody>
						{users.map((user) => (
							<TableRow key={user.EmailAddress}>
								<TableCell padding="checkbox"><Checkbox /></TableCell>
								<TableCell>{user.FirstName}</TableCell>
								<TableCell>{user.LastName}</TableCell>
							</TableRow>
						))}
					</TableBody>
				</Table>
			</TableContainer>
		</div>
	);
}

export default UserListTable;