import React from 'react';

const AuthContext = React.createContext({
    token: '',
    login: (usr, pwd) => {},
    logout: () => { }
});

export default AuthContext;