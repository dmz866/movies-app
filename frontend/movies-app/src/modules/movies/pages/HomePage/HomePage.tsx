import { useCallback } from 'react';
import { useNavigate } from 'react-router';
import { ToastContainer } from 'react-toastify';
import { BasicContainer } from '../../../common/component';
import { ACTORS_PATH, MOVIES_PATH } from '../../constants/route-paths';

export const HomePage = () => {
    const navigate = useNavigate();
    const navigateTo = useCallback((route: string) => {
        navigate(route);
    }, [navigate]);

    return (
        <BasicContainer>
            <div className='flex-row'>
                <p className="text-3xl font-bold my-2">Movies App</p>
                <div className="flex justify-center gap-8">
                    <div onClick={() => navigateTo(MOVIES_PATH)}>
                        <p className="text-3xl font-bold my-2">Movies</p>
                        <img className='hover:cursor-pointer' alt='movie' src='/images/movie.jpeg' height={300} width={200} />
                    </div>
                    <div onClick={() => navigateTo(ACTORS_PATH)}>
                        <p className="text-3xl font-bold my-2">Actors</p>
                        <img className='hover:cursor-pointer' alt='actors' src='/images/rock.jpg' height={300} width={150} />
                    </div>
                </div>
                <ToastContainer /></div>
        </BasicContainer>
    );
};