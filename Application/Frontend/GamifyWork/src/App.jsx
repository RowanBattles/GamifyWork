import { useState } from 'react'
import reactLogo from './assets/react.svg'
import viteLogo from '/vite.svg'
import './App.css'

export default function App() {
	return (
		<>
			<div className='overflow-hidden'>
				{renderTaskTable()}
				<div className='h-screen flex bg-gray-600 h-screen'></div>
			</div>
    	</>
  	)

	function renderTaskTable(){
    	return(
			<>
				<table className='w-full h-full text-sm text-left text-gray-500 dark:text-gray-400'>
					<thead className='text-xs text-gray-700 uppercase bg-gray-50 dark:bg-gray-700 dark:text-gray-400'>
						<tr>
							<th scope='col' className='px-6 py-3'>TaskID (PK)</th>
							<th scope='col' className='px-6 py-3'>Title</th>
							<th scope='col' className='px-6 py-3'>Description</th>
							<th scope='col' className='px-6 py-3'>Points</th>
							<th scope='col' className='px-6 py-3'>Completed</th>
							<th scope='col' className='px-6 py-3'>Recurring</th>
							<th scope='col' className='px-6 py-3'>RecurrenceType</th>
							<th scope='col' className='px-6 py-3'>RecurrenceInterval</th>
							<th scope='col' className='px-6 py-3'>NexthueDate</th>
							<th scope='col' className='px-6 py-3'>UserID</th>
						</tr>
					</thead>
					<tbody>
						<tr className='bg-white border-b dark:bg-gray-800 dark:border-gray-700'>
							<th scope='row' className='px-6 py-4 font-medium text-gray-900 whitespace-nowrap dark:text-white'>1</th>
							<td className='px-6 py-4'>Reading</td>
							<td className='px-6 py-4'>Read for atleast 30 min</td>
							<td className='px-6 py-4'>50</td>
							<td className='px-6 py-4'>No</td>
							<td className='px-6 py-4'>Yes</td>
							<td className='px-6 py-4'>Weekly</td>
							<td className='px-6 py-4'>2</td>
							<td className='px-6 py-4'>3-10-2023</td>
							<td className='px-6 py-4'>1e</td>
						</tr>
					</tbody>
				</table>
      		</>
    	)
  	}
}
