//import React, { useState, useEffect } from 'react';
import './App.css';

import AddBook from './components/Books/AddBook';
import Books from './components/Books/Books';
import Login from './components/Auth/Login';
import Register from './components/Auth/Register';
import { Navigate, Route, Routes } from 'react-router-dom';


const App = () => {

  return (
     <Routes>
        <Route path="/" element={<Navigate to="/login"/>}/>
        <Route path="/login" element={<Login />}/>
        <Route path="/register" element={<Register />} />
        <Route path="/addbooks" element={<AddBook /> } />
        <Route path="/books" element={<Books />} />        
      </Routes>
  );
}

export default App;