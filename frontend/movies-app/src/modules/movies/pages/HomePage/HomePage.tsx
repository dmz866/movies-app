import { useCallback } from 'react';
import { useNavigate } from 'react-router';
import { ToastContainer } from 'react-toastify';
import { BasicContainer } from '../../../common/components';
import { ACTORS_PATH, MOVIES_PATH } from '../../constants/route-paths';

export const HomePage = () => {
    const navigate = useNavigate();
    const navigateTo = useCallback((route: string) => {
        navigate(route);
    }, [navigate]);

    return (
        <BasicContainer>
            <div className='flex-row'>
                <div className="flex justify-center gap-8">
                    <div className='hover:cursor-pointer' onClick={() => navigateTo(MOVIES_PATH)}>
                        <p className="text-white text-5xl font-bold my-2">Movies</p>
                        <img className='w-64 h-96 object-fill rounded-lg' alt='movie' src='/images/movie.jpeg' />
                    </div>
                    <div className='hover:cursor-pointer' onClick={() => navigateTo(ACTORS_PATH)}>
                        <p className="text-white text-5xl font-bold my-2">Actors</p>
                        <img className='w-64 h-96 object-fill rounded-lg' alt='actors' src='/images/rock.jpg' />
                    </div>
                </div>
                <ToastContainer /></div>
        </BasicContainer>
    );
};