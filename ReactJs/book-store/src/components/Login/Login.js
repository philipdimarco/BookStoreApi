import React from 'react';
import { useRef, useState, useEffect, useContext } from 'react';
import { AuthContext } from '../../context/AuthProvider';

import './Login.css';

const Login = () => {
    const { setAuth } = useContext(AuthContext);

    const userRef = useRef();
    const errRef = useRef();

    const [user, setUser] = useState('');
    const [pwd, setPwd] = useState('');
    const [errMsg, setErrMsg] = useState('');
    
    const [success, setSuccess] = useState(false); // replaces React Router

    useEffect( () => {
        userRef.current.focus();
    }, []);

    useEffect( () => {
        setErrMsg('');
    }, [user,pwd]);

    const handleSubmit = async (event) => {
        event.preventDefault();
        console.log(`User:${user} Pwd:${pwd}`);
        setUser('');
        setPwd('');
        setSuccess(true);
    }
  return (
    <>
    {success ? (
        <section>
            <h1>You are logged in!</h1>
            <br />
            <p>
                <a href='#'>Go to Home</a>
            </p>
        </section> 
    ) : (
        <section>
            <p ref={errRef} className={errMsg ? "errmsg" : "offscreen" }
            aria-live="assertive">{errMsg}</p>
            <h1>Sign In</h1>
            <form onSubmit={handleSubmit}>
                <label htmlFor="username">Username:</label>
                <input type="text" 
                        id="username" 
                        ref={userRef}
                        autoComplete="off"
                        onChange={(event) => setUser(event.target.value)}
                        value={user}
                        required
                />
                <label htmlFor="password">Password:</label>
                <input type="password" 
                        id="password" 
                        autoComplete="off"
                        onChange={(event) => setPwd(event.target.value)}
                        value={pwd}
                        required
                />
                <button>Sign In</button>
                <p>
                    Need an Account?<br />
                    <span className="line"
                        // {put react router link here instead of below}
                        >
                        <a href='#'>Sign Up</a>
                    </span>
                </p>
            </form>
        </section>
    )}
    </>
  )
}

export default Login