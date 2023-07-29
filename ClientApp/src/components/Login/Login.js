import React, { Fragment, Component } from 'react';

export class Login extends Component {
  static displayName = Login.name;

  render() {
    return (
        <Fragment>
            <h1>Inicio de sesion</h1>
            <form>
                <div>
                    <input
                        className="usuario"
                        type="text"
                        name="nombre_usuario"
                        placeholder="usuario o correo"
                    />
                </div>
                <div>
                    <input
                        className="contraseña"
                        type="password"
                        name="contraseña"
                        placeholder="clave"
                    />
                </div>
                <div>
                    <label className="olvidoClave">Olvido su clave?</label>
                </div>
                <button type="botton">Iniciar sesion</button>
            </form>
        </Fragment>
    );
  }
}
