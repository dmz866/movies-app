import { BrowserRouter, Route, Routes } from 'react-router';
import { ACTORS_PATH, MOVIES_PATH } from '../constants';
import { ActorsPage } from '../pages/ActorsPage/ActorsPage';
import { HomePage } from '../pages/HomePage/HomePage';
import { MoviesPage } from '../pages/MoviesPage/MoviesPage';

export const NavigationRouter = () => {
    return (
        <BrowserRouter>
            <Routes>
                <Route path='/' element={<HomePage />} />
                <Route path={MOVIES_PATH} element={<MoviesPage />} />
                <Route path={ACTORS_PATH} element={<ActorsPage />} />O
            </Routes>
        </BrowserRouter>
    );
}
