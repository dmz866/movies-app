import { ToastContainer } from 'react-toastify';

export const HomePage = () => {
    return (
        <>
            <div className="flex-row">
                <div className="w-[800px] mx-auto justify-center flex mt-10">
                    <div className="w-full">
                        <p className="text-3xl font-bold my-2">Movies App</p>
                        <div className="flex justify-center">
                        </div>
                    </div>
                </div>
            </div>
            <ToastContainer />
        </>
    );
};