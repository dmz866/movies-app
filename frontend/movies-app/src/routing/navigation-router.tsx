import { BrowserRouter, Route, Routes } from 'react-router';
import { HOME_PATH } from '../constants';
import { HomePage } from '../pages/HomePage';

export const NavigationRouter = () => {
    return (
        <BrowserRouter>
            <Routes>
                <Route path='/' element={<HomePage />} />
                <Route path={HOME_PATH} element={<HomePage />}
                />
            </Routes>
        </BrowserRouter>
    );
}
