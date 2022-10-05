import React, { useState } from 'react';

import './BooksDashboard.css';
import Card from '../GUI/Card';

const BooksDashboard = (props) => {
  const [title , setTitle] = useState(props.title);
    
  const description = props.description;
  const author = props.author;
  const price = props.price;
    
  const handleClick =  () => {
    setTitle('New Book 1');
  };

 return <Card className="dashboard-item">
  <div className="dashboard-item__title">{title}</div>
  <div className="dashboard-item__description">
  <div className="dashboard-item__desc_auth">{description}</div>
    <div className="dashboard-item__desc_auth">{author}</div>
    <div className="dashboard-item__price">${price}</div>
  </div>
  <button className='button_c' onClick={handleClick} >Change Title</button>
 </Card>
}


export default BooksDashboard;